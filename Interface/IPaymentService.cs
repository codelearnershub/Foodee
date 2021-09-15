using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IPaymentService
    {
        public Payment Add(Payment payment);
        public Payment Update(Payment payment);
        public void Delete(int id);
        public List<Payment> GetAll();
        public Payment FindById(int id);
        public Payment FindByReference(string PaymentRef);
    }
}
