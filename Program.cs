namespace Voting_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Option Part
            Console.WriteLine(@"
    ███╗   ███╗ █████╗ ██╗███╗   ██╗    ██████╗  █████╗  ██████╗ ███████╗
    ████╗ ████║██╔══██╗██║████╗  ██║    ██╔══██╗██╔══██╗██╔════╝ ██╔════╝
    ██╔████╔██║███████║██║██╔██╗ ██║    ██████╔╝███████║██║  ███╗█████╗  
    ██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██╔═══╝ ██╔══██║██║   ██║██╔══╝  
    ██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ██║     ██║  ██║╚██████╔╝███████╗
    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                     ");
            Console.WriteLine("Made by Hitman-2005/Moirangthem Henthoiba");
            Console.WriteLine();
            Console.Write(@"
[1] Admin (Requires Username & Password)
[2] Vote
[3] Exit

[#] Select: ");
            string main_options = Console.ReadLine(); // User input for writing the option no.

            while (Convert.ToString(main_options) != "1" && Convert.ToString(main_options) != "2" && Convert.ToString(main_options) != "3")
            {
                // While Loop for giving wrong option
                Console.WriteLine();
                Console.WriteLine("Wrong Option, Please try again!");
                Console.Write("[#] Select: ");
                main_options = Console.ReadLine();
            }
            if (Convert.ToString(main_options) == "1")
            {
                // Admin Part
                Console.Clear();
                Console.WriteLine(@" 
    █████╗ ██████╗ ███╗   ███╗██╗███╗   ██╗    ██████╗  █████╗  ██████╗ ███████╗
    ██╔══██╗██╔══██╗████╗ ████║██║████╗  ██║    ██╔══██╗██╔══██╗██╔════╝ ██╔════╝
    ███████║██║  ██║██╔████╔██║██║██╔██╗ ██║    ██████╔╝███████║██║  ███╗█████╗  
    ██╔══██║██║  ██║██║╚██╔╝██║██║██║╚██╗██║    ██╔═══╝ ██╔══██║██║   ██║██╔══╝  
    ██║  ██║██████╔╝██║ ╚═╝ ██║██║██║ ╚████║    ██║     ██║  ██║╚██████╔╝███████╗
    ╚═╝  ╚═╝╚═════╝ ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                             ");
                Console.WriteLine();
                Console.Write("[#] USERNAME: ");
                string admin_username = Console.ReadLine();
                Console.Write("[#] PASSWORD: ");
                string admin_password = Console.ReadLine();

                string read_admin_username = File.ReadAllText("admin\\username.txt");
                string read_admin_password = File.ReadAllText("admin\\password.txt");
                while (admin_username != Convert.ToString(read_admin_username) || admin_password != Convert.ToString(read_admin_password))
                {
                    // While loop for giving wrong Username and Password
                    Console.WriteLine();
                    Console.WriteLine("Wrong Username/Password");
                    Console.Write("[#] USERNAME: ");
                    admin_username = Console.ReadLine();
                    Console.Write("[#] PASSWORD: ");
                    admin_password = Console.ReadLine();
                }

                if (admin_username == read_admin_username && admin_password == read_admin_password)
                {
                    Console.WriteLine("You are login as admin!");
                    // Admin Panel Part

                    Console.Clear();
                    Console.Write(@"
[1] REMOVE VOTES
[2] ADD VOTES (Only Admin can do this option)

[#] Select: ");
                    string admin_panel_input = Console.ReadLine();
                    while (admin_panel_input != "1" && admin_panel_input != "2")
                    {
                        // Using while loop for giving wrong option
                        Console.WriteLine();
                        Console.WriteLine("Wrong option, try again!");
                        Console.Write("[#] Select: ");
                        admin_panel_input = Console.ReadLine();
                    }
                    if (admin_panel_input == "1")
                    {
                        // Admin Panel Option 1 Part for removing votes
                        Console.Clear();
                        string read_bjp_vote = File.ReadAllText("party\\bjp\\total.txt");
                        string read_congress_vote = File.ReadAllText("party\\congress\\total.txt");
                        Console.Write(@"
[1] BJP
[2] CONGRESS

[#] Select: ");
                        string remove_votes_party = Console.ReadLine();
                        while (remove_votes_party != "1" && remove_votes_party != "2")
                        {
                            // Using while loop for giving wrong option
                            Console.WriteLine();
                            Console.WriteLine("Wrong option, try again");
                            Console.Write("[#] Select: ");
                            remove_votes_party = Console.ReadLine();
                        }
                        if (remove_votes_party == "1")
                        {
                            // Removing Votes for BJP
                            Console.WriteLine($"Current BJP Votes: {read_bjp_vote}");
                            Console.Write("Amount of Votes to remove: ");
                            string vote_remove_amount = Console.ReadLine();
                            if (Convert.ToInt32(vote_remove_amount) < Convert.ToInt32(read_bjp_vote))
                            {
                                int update_votes_bjp = Convert.ToInt32(read_bjp_vote) - Convert.ToInt32(vote_remove_amount);
                                File.WriteAllText("party\\bjp\\total.txt", Convert.ToString(update_votes_bjp));
                                Console.WriteLine($"Current BJP Vote: {Convert.ToString(update_votes_bjp)}");
                                Console.ReadLine();
                            }
                            else if (Convert.ToInt32(vote_remove_amount) > Convert.ToInt32(read_bjp_vote))
                            {
                                Console.WriteLine("Amount of remove votes is more than the actual votes for the party");
                                Console.ReadLine();
                            }
                        }
                        else if (remove_votes_party == "2")
                        {
                            // Removing Votes for Congress
                            Console.WriteLine($"Current Congress Votes: {read_congress_vote}");
                            Console.Write("Amount of Votes to remove: ");
                            string vote_remove_amount = Console.ReadLine();
                            if (Convert.ToInt32(vote_remove_amount) < Convert.ToInt32(read_congress_vote))
                            {
                                int update_votes_congress = Convert.ToInt32(read_congress_vote) - Convert.ToInt32(vote_remove_amount);
                                File.WriteAllText("party\\congress\\total.txt", Convert.ToString(update_votes_congress));
                                Console.WriteLine($"Current BJP Vote: {Convert.ToString(update_votes_congress)}");
                                Console.ReadLine();
                            }
                            else if (Convert.ToInt32(vote_remove_amount) > Convert.ToInt32(read_congress_vote))
                            {
                                Console.WriteLine("Amount of remove votes is more than the actual votes for the party");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Remove Votes Party: Error");
                        }

                        Console.ReadLine();
                    }
                    else if (admin_panel_input == "2")
                    {
                        // Admin Panel for giving any amount of votes to a party
                        string read_bjp_vote = File.ReadAllText("party\\bjp\\total.txt");
                        string read_congress_vote = File.ReadAllText("party\\congress\\total.txt");
                        Console.Write(@"
[1] BJP
[2] CONGRESS

[#] Select: ");
                        string add_votes = Console.ReadLine();
                        while (add_votes != "1" && add_votes != "2")
                        {
                            // Using while loop for giving wrong option
                            Console.WriteLine();
                            Console.WriteLine("Wrong option, try again!");
                            Console.WriteLine("[#] Select: ");
                            add_votes= Console.ReadLine();
                        }
                        if (add_votes== "1")
                        {
                            // Add Votes for BJP
                            Console.Write("Amount of votes to add: ");
                            string add_bjp_votes = Console.ReadLine();
                            if (Convert.ToInt32(add_bjp_votes) >= 0)
                            {
                                int add_vote_update = Convert.ToInt32(add_bjp_votes) + Convert.ToInt32(read_bjp_vote);
                                File.WriteAllText("party\\bjp\\total.txt", Convert.ToString(add_vote_update));
                                Console.WriteLine($"Current BJP Vote: {Convert.ToString(add_vote_update)}");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("BJP ADD: Error");
                                Console.ReadLine();
                            }
                        }
                        else if (add_votes=="2")
                        {
                            // Add Votes for Congress
                            Console.Write("Amount of votes to add: ");
                            string add_congress_votes = Console.ReadLine();
                            if (Convert.ToInt32(add_congress_votes) >= 0)
                            {
                                int add_vote_update = Convert.ToInt32(add_congress_votes) + Convert.ToInt32(read_congress_vote);
                                File.WriteAllText("party\\congress\\total.txt", Convert.ToString(add_vote_update));
                                Console.WriteLine($"Current BJP Vote: {Convert.ToString(add_vote_update)}");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("CONGRESS ADD: Error");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
            else if (Convert.ToString(main_options) == "2")
            {
                // Vote Part
                Console.Clear();
                Console.WriteLine(@"
    ██╗   ██╗ ██████╗ ████████╗███████╗    ██████╗  █████╗  ██████╗ ███████╗
    ██║   ██║██╔═══██╗╚══██╔══╝██╔════╝    ██╔══██╗██╔══██╗██╔════╝ ██╔════╝
    ██║   ██║██║   ██║   ██║   █████╗      ██████╔╝███████║██║  ███╗█████╗  
    ╚██╗ ██╔╝██║   ██║   ██║   ██╔══╝      ██╔═══╝ ██╔══██║██║   ██║██╔══╝  
     ╚████╔╝ ╚██████╔╝   ██║   ███████╗    ██║     ██║  ██║╚██████╔╝███████╗
      ╚═══╝   ╚═════╝    ╚═╝   ╚══════╝    ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                        ");
                Console.WriteLine();
                Console.Write(@"
[1] GIVE VOTE
[2] VOTE'S/PARTY (checking all votes for each party)
[3] Exit

[#] Select: ");
                string vote_option = Console.ReadLine();
                while (Convert.ToString(vote_option) != "1" && Convert.ToString(vote_option) != "2" && Convert.ToString(vote_option) != "3")
                {
                    // Using While loop for giving wrong option
                    Console.WriteLine();
                    Console.WriteLine("Wrong Option!");
                    Console.Write("[#] Select: ");
                    vote_option = Console.ReadLine();
                }
                if (Convert.ToString(vote_option) == "1")
                {
                    // Part Vote Part
                    Console.Clear();
                    Console.Write(@"
[1] BJP
[2] CONGRESS

[#] Select: ");
                    string vote_party = Console.ReadLine();
                    while (Convert.ToString(vote_party) != "1" && Convert.ToString(vote_party) != "2")
                    {
                        // Using While loop for giving wrong option
                        Console.WriteLine();
                        Console.WriteLine("Wrong Option");
                        Console.Write("[#] Select: ");
                        vote_party = Console.ReadLine();
                    }
                    if (Convert.ToString(vote_party) == "1")
                    {
                        // BJP Party Part
                        int vote_per_person = 1;
                        string read_current_vote = File.ReadAllText("party\\bjp\\total.txt");
                        int update_vote = vote_per_person + Convert.ToInt32(read_current_vote);
                        File.WriteAllText("party\\bjp\\total.txt", Convert.ToString(update_vote));
                        Console.WriteLine("1 Vote has been added");
                        Console.WriteLine();
                        Console.WriteLine($"Total Vote for BJP: {Convert.ToString(update_vote)}");
                        Console.ReadLine();
                    }
                    else if (Convert.ToString(vote_party) == "2")
                    {
                        // CONGRESS Party Part
                        int vote_per_person = 1;
                        string read_current_vote = File.ReadAllText("party\\congress\\total.txt");
                        int update_vote = vote_per_person + Convert.ToInt32(read_current_vote);
                        File.WriteAllText("party\\congress\\total.txt", Convert.ToString(update_vote));
                        Console.WriteLine("1 Vote has been added");
                        Console.WriteLine();
                        Console.WriteLine($"Total Vote for CONGRESS: {Convert.ToString(update_vote)}");
                        Console.ReadLine();
                    }
                }
                else if (Convert.ToString(vote_option) == "2")
                {
                    // Checking Votes for Party's
                    Console.Clear();
                    Console.Write(@"
[1] BJP
[2] CONGRESS

[#] Select: ");
                    string check_votes = Console.ReadLine();

                    while (Convert.ToString(check_votes) != "1" && Convert.ToString(check_votes) != "2")
                    {
                        Console.WriteLine();
                        Console.WriteLine("[#] Select: ");
                        check_votes = Console.ReadLine();
                    }

                    if (Convert.ToString(check_votes) == "1")
                    {
                        string read_bjp_vote = File.ReadAllText("party\\bjp\\total.txt");
                        Console.WriteLine($"BJP CURRENT VOTE: {read_bjp_vote}");
                        Console.ReadLine();
                    }
                    else if (Convert.ToString(check_votes) == "2")
                    {
                        string read_congress_vote = File.ReadAllText("party\\congress\\total.txt");
                        Console.WriteLine($"CONGRESS CURRENT VOTE: {read_congress_vote}");
                        Console.ReadLine();
                    }
                }
                else if (Convert.ToString(vote_option) == "3")
                {
                    // Nothing is put here cuz the command is to exit
                }
            }
            else if (main_options == "3")
            {
                // Nothing is put here cuz the command is to exit
            }
        }
    }
}