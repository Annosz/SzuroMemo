using System;
using System.Collections.Generic;
using System.Text;
using SzuroMemo.Dal.Dtos;
using System.Linq;
using SzuroMemo.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SzuroMemo.Dal.Services
{
    public class MedicalRecordService
    {
        public MedicalRecordService(SzuroMemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SzuroMemoDbContext DbContext { get; }

        public MedicalRecordDto GetMedicalRecordToUser(int userId)
        {
            var record = DbContext.MedicalRecord.FirstOrDefault(m => m.UserId == userId);
            if (record == null)
                return null;

            var recordDto = new MedicalRecordDto
            {
                Id = record.Id,
                Gender = record.Gender,
                Height = record.Height,
                Weight = record.Weight
            };

            return recordDto;
        }

        public int PutMedicalRecordToUser(int userId, MedicalRecordDto record)
        {
            var medicalRecord = DbContext.MedicalRecord.FirstOrDefault(m => m.UserId == userId);

            if (medicalRecord == null)
            {
                medicalRecord = new MedicalRecord
                {
                    User = DbContext.Users.First(u => u.Id == userId),
                    UserId = userId
                };
                DbContext.MedicalRecord.Add(medicalRecord);
            }

            medicalRecord.Gender = record.Gender;
            medicalRecord.Height = record.Height;
            medicalRecord.Weight = record.Weight;

            return DbContext.SaveChanges();
        }
    }
}
