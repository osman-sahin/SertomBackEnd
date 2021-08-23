using Core.IService;
using Core.IServices;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Core.Services
{
    public class ClinicService : IGenericService<Clinic>
    {
        private readonly MedyanaDbContext _dbContext;
        private readonly ILogService _log;

        public ClinicService(MedyanaDbContext dbContext, ILogService log)
        {
            _dbContext = dbContext;
            _log = log;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Clinic clinic = await _dbContext.Clinics.FindAsync(id);
                if (clinic != null)
                {
                    _dbContext.Clinics.Remove(clinic);
                    await _dbContext.SaveChangesAsync();
                    _log.Info("Deleted on " + DateTime.Now);
                    return true;
                }

            }
            catch (Exception ex)
            {
                _log.Error("Clinic Delete Error: " + ex.Message);
            }
            return false;
        }

        public async Task<List<Clinic>> Get()
        {
            try
            {
                var clinics = await Task.Run(() => _dbContext.Clinics.ToListAsync());
                return clinics;
            }
            catch (Exception)
            {
                _log.Error("Clinic/Get Error");
                return null;
            }
        }

        public async Task<Clinic> Get(int id)
        {
            try
            {
                var clinic = await Task.Run(() => _dbContext.Clinics.SingleOrDefault(c => c.Id == id));
                if (clinic is null)
                {
                    return null;
                }
                return clinic;
            }
            catch (Exception)
            {
                _log.Error("Clinic/Get/" + id + " Error");
                return null;
            }
        }

        public async Task<Clinic> Post(Clinic entity)
        {
            try
            {
                entity.CreationDate = DateTime.Now;

                await _dbContext.Clinics.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                _log.Info("Clinic created: " + entity.Name);

                entity.Success = true;
                entity.Status = 200;
                entity.Message = entity.Name + " is created successfully!";
            }
            catch (Exception ex)
            {
                _log.Error("Create clinic error" + ex.Message);
                entity.Message = "An error occured";
                entity.Status = 500;
            }
            return entity;
        }

        public async Task<Clinic> Put(int id, Clinic entity)
        {
            try
            {
                var clinic = await Task.Run(() => _dbContext.Clinics.SingleOrDefault(c => c.Id == id));

                if (clinic is null)
                {
                    entity.Status = 400;
                    entity.Message = "Clinic not found";

                    return entity;
                }

                entity.ModificationDate = DateTime.Now;

                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                _log.Info("Clinic created: " + entity.Name);

                entity.Success = true;
                entity.Status = 200;
                entity.Message = entity.Name + " is updated successfully!";

            }
            catch (Exception ex)
            {
                _log.Error("Update clinic error" + ex.Message);
                entity.Message = "An error occured";
                entity.Status = 500;
            }

            return entity;
        }

        private async Task<bool> IsExist(int id)
        {
            return await _dbContext.Clinics.AnyAsync(e => e.Id == id);
        }
    }
}
