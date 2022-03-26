namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<ImportDepartmentCellsDto> dtoDepartmentCells = JsonConvert.DeserializeObject<ICollection<ImportDepartmentCellsDto>>(jsonString);

            HashSet<Department> departments = new HashSet<Department>();

            foreach (ImportDepartmentCellsDto dtoDeptCell in dtoDepartmentCells)
            {
                if (!IsValid(dtoDeptCell) || !dtoDeptCell.Cells.All(IsValid) ||
                    dtoDeptCell.Cells.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = dtoDeptCell.Name,
                    Cells = dtoDeptCell.Cells
                    .Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<ImportPrisonerMailsDto> dtoPrisonerMails = JsonConvert.DeserializeObject<ICollection<ImportPrisonerMailsDto>>(jsonString);

            HashSet<Prisoner> prisoners = new HashSet<Prisoner>();

            foreach (ImportPrisonerMailsDto dtoPrsMail in dtoPrisonerMails)
            {
                if (!IsValid(dtoPrsMail) || !dtoPrsMail.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(dtoPrsMail.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;

                if (!string.IsNullOrWhiteSpace(dtoPrsMail.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact(dtoPrsMail.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner
                {
                    FullName = dtoPrsMail.FullName,
                    Nickname = dtoPrsMail.Nickname,
                    Age = dtoPrsMail.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = dtoPrsMail.Bail,
                    CellId = dtoPrsMail.CellId,
                    Mails = dtoPrsMail.Mails
                    .Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    })
                    .ToList()
                };

                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), xmlRoot);

            StringReader reader = new StringReader(xmlString);

            ImportOfficerDto[] dtoOfficers = (ImportOfficerDto[])xmlSerializer.Deserialize(reader);

            HashSet<Officer> officers = new HashSet<Officer>();

            foreach (ImportOfficerDto dtoOfficer in dtoOfficers)
            {
                if (!IsValid(dtoOfficer))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = dtoOfficer.FullName,
                    Salary = dtoOfficer.Salary,
                    Position = Enum.Parse<Position>(dtoOfficer.Position),
                    Weapon = Enum.Parse<Weapon>(dtoOfficer.Weapon),
                    DepartmentId = dtoOfficer.DepartmentId,
                    OfficerPrisoners = dtoOfficer.Prisoners
                    .Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    })
                    .ToArray()
                };

                officers.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }
    }
}
 