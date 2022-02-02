using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService.Interface
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
