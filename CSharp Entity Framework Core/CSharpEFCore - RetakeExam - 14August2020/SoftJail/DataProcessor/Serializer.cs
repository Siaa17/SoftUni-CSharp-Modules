namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = decimal.Parse(p.PrisonerOfficers.Sum(x => x.Officer.Salary).ToString("F2"))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            string prisonersAsJson = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return prisonersAsJson;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            string[] prisonerNamesParts = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Prisoners");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportPrisonerDto[] prisonersInbox = context.Prisoners
                .Where(x => prisonerNamesParts.Contains(x.FullName))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                    .Select(em => new ExportEncryptedMessageDto
                    {
                        Description = string.Join("", em.Description.Reverse())
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            xmlSerializer.Serialize(writer, prisonersInbox, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}