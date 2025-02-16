using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Blue_1
    {
        public struct Response
        {

            private string name;
            private string surname;
            private int votes;

            public string Name
            {
                get
                {
                    if (name == null)
                        return "";
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    if (surname == null)
                        return "";
                    return surname;
                }
            }

            public int Votes
            {
                get
                {
                    if (votes == null)
                        return 0;
                    return votes;
                }
            }

            public Response(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.votes = 0;
            }

            public int CountVotes(Response[] responses)
            {

                int count = 0;
                foreach (var response in responses)
                {
                    if (response.Name == this.Name && response.Surname == this.Surname)
                    {
                        count++;
                    }
                }

                this.votes = count;
                return count;
            }
        }
    }
}
