using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF6Model;

namespace EF6Model.Service
{
    public class MessageService
    {
        public List<MessageContract> Find()
        {
            using (EFTestContext context = new EFTestContext())
            {
                return context.Message.ToList();
            }
        }

    }
}
