using FOODEE.Context;
using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Repository
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly FoodeeDbContext _dbContext;
        public PaymentRepository(FoodeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Payment Add(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
            return payment;
        }
        public Payment FindById(int id)
        {
            return _dbContext.Payments.Find(id);
        }

        public void Delete(int id)
        {
            var payment = FindById(id);
            if (payment != null)
            {
                _dbContext.Payments.Remove(payment);
                _dbContext.SaveChanges();
            }
        }
        public Payment Update(Payment payment)
        {
            _dbContext.Payments.Update(payment);
            _dbContext.SaveChanges();
            return payment;
        }
        public List<Payment> GetAll()
        {
            return _dbContext.Payments.ToList();

        }
        public bool Exists(int id)
        {
            return _dbContext.Payments.Any(e => e.Id == id);
        }
    }
}
