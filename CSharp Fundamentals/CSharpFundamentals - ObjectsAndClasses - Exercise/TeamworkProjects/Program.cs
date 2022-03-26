using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamData = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creator = teamData[0];
                string teamName = teamData[1];

                Team existingTeam = GetTeamByName(teams, teamName);

                if (existingTeam != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (CreatorExists(teams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team()
                {
                    Creator = creator,
                    TeamName = teamName
                };

                teams.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!"); 
            }

            string line = String.Empty;

            while ((line = Console.ReadLine()) != "end of assignment")
            {
                string[] teamParts = line
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string user = teamParts[0];
                string teamName = teamParts[1];

                Team existingTeam = GetTeamByName(teams, teamName);

                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsMember(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                existingTeam.Members.Add(user);
            }

            List<Team> sorted = teams
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();

            foreach (Team team in sorted)
            {
                if (team.Members.Count == 0)
                {
                    break;
                }

                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                List<string> sortedMembers = team.Members
                    .OrderBy(m => m)
                    .ToList();

                foreach (string member in sortedMembers)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            List<Team> disbandedTeams = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.TeamName)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (Team team in disbandedTeams)
            {
                Console.WriteLine(team.TeamName);
            }
        }

        static bool CreatorExists(List<Team> teams, string creator)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == creator)
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsMember(List<Team> teams, string user)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == user)
                {
                    return true;
                }

                foreach (string member in team.Members)
                {
                    if (member == user)
                    {
                        return true;
                    }
                }
            }

            return false;
        } 

        static Team GetTeamByName(List<Team> teams, string teamName)
        {
            foreach (Team team in teams)
            {
                if (team.TeamName == teamName)
                {
                    return team;
                }
            }

            return null;
        }
    }

    class Team
    {
        public Team()
        {
            Members = new List<string>();
        }

        public string  TeamName { get; set; }

        public string  Creator { get; set; }

        public List<string> Members { get; set; }
    }
}
