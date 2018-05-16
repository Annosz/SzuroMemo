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
                FullName = record.FullName,
                BirthName = record.BirthName,
                MotherBirthName = record.MotherBirthName,
                Address = record.Address,
                Nationality = record.Nationality,
                TajNumber = record.TajNumber,

                Gender = record.Gender,
                Height = record.Height,
                Weight = record.Weight,
                BloodType = record.BloodType,

                FatherAsthma = record.FatherAsthma,
                FatherDiabetes = record.FatherDiabetes,
                FatherAllergy = record.FatherAllergy,
                FatherHeartDisease = record.FatherHeartDisease,
                FatherTumour = record.FatherTumour,
                FatherObese = record.FatherObese,
                MotherAsthma = record.MotherAsthma,
                MotherDiabetes = record.MotherDiabetes,
                MotherAllergy = record.MotherAllergy,
                MotherHeartDisease = record.MotherHeartDisease,
                MotherTumour = record.MotherTumour,
                MotherObese = record.MotherObese
            };

            if (record.LastScreenings != null)
                recordDto.LastScreenings = record.LastScreenings.Select(l => new { l.Screening.Name, l.Time }).ToDictionary(e => e.Name, e => (DateTime?)e.Time);
            else
                recordDto.LastScreenings = new Dictionary<string, DateTime?>();

            foreach (string screening in DbContext.Screening.Select(s => s.Name))
            {
                if (!recordDto.LastScreenings.ContainsKey(screening))
                    recordDto.LastScreenings.Add(screening, null);
            }

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

            medicalRecord.FullName = record.FullName;
            medicalRecord.BirthName = record.BirthName;
            medicalRecord.MotherBirthName = record.MotherBirthName;
            medicalRecord.Address.ZipCode = record.Address.ZipCode;
            medicalRecord.Address.Settlement = record.Address.Settlement;
            medicalRecord.Address.StreetAddress = record.Address.StreetAddress;
            medicalRecord.Nationality = record.Nationality;
            medicalRecord.TajNumber = record.TajNumber;

            medicalRecord.Gender = record.Gender;
            medicalRecord.Height = record.Height;
            medicalRecord.Weight = record.Weight;
            medicalRecord.BloodType = record.BloodType;

            medicalRecord.FatherAsthma = record.FatherAsthma;
            medicalRecord.FatherDiabetes = record.FatherDiabetes;
            medicalRecord.FatherAllergy = record.FatherAllergy;
            medicalRecord.FatherHeartDisease = record.FatherHeartDisease;
            medicalRecord.FatherTumour = record.FatherTumour;
            medicalRecord.FatherObese = record.FatherObese;
            medicalRecord.MotherAsthma = record.MotherAsthma;
            medicalRecord.MotherDiabetes = record.MotherDiabetes;
            medicalRecord.MotherAllergy = record.MotherAllergy;
            medicalRecord.MotherHeartDisease = record.MotherHeartDisease;
            medicalRecord.MotherTumour = record.MotherTumour;
            medicalRecord.MotherObese = record.MotherObese;

            if (medicalRecord.LastScreenings == null)
                medicalRecord.LastScreenings = new List<LastScreening>();
            foreach (var lastScreening in record.LastScreenings)
            {
                var oldLastScreenind = medicalRecord.LastScreenings.FirstOrDefault(l => l.Screening.Name == lastScreening.Key);
                if (lastScreening.Value == null)
                    medicalRecord.LastScreenings.Remove(oldLastScreenind);
                else
                {
                    if (oldLastScreenind == null)
                        medicalRecord.LastScreenings.Add(new LastScreening { Screening = DbContext.Screening.First(s => s.Name == lastScreening.Key), Time = lastScreening.Value.Value });
                    else
                        oldLastScreenind.Time = lastScreening.Value.Value;
                }

            }

            return DbContext.SaveChanges();
        }
    }
}
