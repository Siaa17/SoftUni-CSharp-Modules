using System;
using System.Collections.Generic;
using System.Linq;
using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputParts = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = inputParts[0];
                string id = inputParts[1];
                string firstName = inputParts[2];
                string lastName = inputParts[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(inputParts[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);

                    soldiersById[id] = @private;
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(inputParts[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < inputParts.Length; i++)
                    {
                        string privateId = inputParts[i];

                        if (!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        lieutenantGeneral.AddPrivate(soldiersById[privateId] as IPrivate);
                    }

                    soldiersById[id] = lieutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(inputParts[4]);
                    string corpsStr = inputParts[5];

                    bool isCorpsValid = Enum.TryParse(corpsStr, out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < inputParts.Length; i += 2)
                    {
                        string partName = inputParts[i];
                        int workedHours = int.Parse(inputParts[i + 1]);

                        IRepair repair = new Repair(partName, workedHours);

                        engineer.AddRepair(repair);
                    }

                    soldiersById[id] = engineer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(inputParts[4]);
                    string corpsStr = inputParts[5];

                    bool isCorpsValid = Enum.TryParse(corpsStr, out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < inputParts.Length; i += 2)
                    {
                        string codeName = inputParts[i];
                        string state = inputParts[i + 1];

                        bool isMissionStateValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionState);

                        commando.AddMission(mission);
                    }

                    soldiersById[id] = commando;
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(inputParts[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }
            }

            foreach (ISoldier soldier in soldiersById.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
