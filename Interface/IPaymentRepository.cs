using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Interface
{
    public interface IPaymentRepository
    {
        public Payment Add(Payment payment);
        public Payment FindById(int id);
        public void Delete(int id);
        public Payment Update(Payment payment);
        public List<Payment> GetAll();
        public bool Exists(int id);
        public Payment FindByReference(string PaymentRef);
    }
}
