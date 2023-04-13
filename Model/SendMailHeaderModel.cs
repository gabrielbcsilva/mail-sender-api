using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mailSender_api.Model
{
    public class SendMailHeaderModel
    {
        public string SmtpAddress {get;set;} 
        public int PortNumber{get;set;} 
        public string EmailFromAddress{get;set;} 
        public string Password{get;set;}
    }
}