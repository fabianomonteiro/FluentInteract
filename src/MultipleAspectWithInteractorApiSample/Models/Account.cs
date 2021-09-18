using System;

namespace LoggingAspectWithProxyApiSample.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Disabled { get; set; }

        public DateTime Created { get; set; }
    }
}
