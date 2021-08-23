using Core.IService;
using Core.IServices;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EquipmentService : IGenericService<Equipment>
    {
        private readonly MedyanaDbContext _dbContext;
        private readonly ILogService _log;
        public EquipmentService(ILogService log, MedyanaDbContext dbContext)
        {
            _log = log;
            _dbContext = dbContext;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Equipment equipment = await _dbContext.Equipments.FindAsync(id);
                if (equipment != null)
                {
                    _dbContext.Equipments.Remove(equipment);
                    await _dbContext.SaveChangesAsync();
                    _log.Info("Deleted on " + DateTime.Now);
                    return true;
                }

            }
            catch (Exception ex)
            {
                _log.Error("Equipment/Delete/"+id +" Error: " + ex.Message);
            }
            return false;
        }

        public async Task<List<Equipment>> Get()
        {
            try
            {
                var equipment = await Task.Run(() => _dbContext.Equipments.ToListAsync());
                return equipment;
            }
            catch (Exception)
            {
                _log.Error("Equipment/Get Error");
                return null;
            }
        }

        public async Task<Equipment> Get(int id)
        {
            try
            {
                var equipment = await Task.Run(() => _dbContext.Equipments.SingleOrDefault(c => c.Id == id));
                if (equipment is null)
                {
                    return null;
                }
                return equipment;
            }
            catch (Exception)
            {
                _log.Error("Equipment/Get/" + id + " Error");
                return null;
            }
        }

        public async Task<Equipment> Post(Equipment entity)
        {
            try
            {
                entity.CreationDate = DateTime.Now;

                await _dbContext.Equipments.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                _log.Info("Equipment created: " + entity.Name);

                entity.Success = true;
                entity.Status = 200;
                entity.Message = entity.Name + " is created successfully!";
            }
            catch (Exception ex)
            {
                _log.Error("Create equipment error" + ex.Message);
                entity.Message = "An error occured";
                entity.Status = 500;
            }
            return entity;
        }

        public async Task<Equipment> Put(int id, Equipment entity)
        {
            try
            {
                var equipment = await Task.Run(() => _dbContext.Equipments.SingleOrDefault(c => c.Id == id));

                if (equipment is null)
                {
                    entity.Status = 400;
                    entity.Message = "Equipment not found";

                    return entity;
                }

                entity.ModificationDate = DateTime.Now;

                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                _log.Info("Equipment created: " + entity.Name);

                entity.Success = true;
                entity.Status = 200;
                entity.Message = entity.Name + " is updated successfully!";

            }
            catch (Exception ex)
            {
                _log.Error("Update equipment error" + ex.Message);
                entity.Message = "An error occured";
                entity.Status = 500;
            }

            return entity;
        }

        private async Task<bool> IsExist(int id)
        {
            return await _dbContext.Equipments.AnyAsync(e => e.Id == id);
        }
    }
}
