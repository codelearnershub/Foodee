using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
        public Payment FindById(int id)
        {
            return paymentRepository.FindById(id);
        }
        public Payment FindByReference(string PaymentRef)
        {
            return paymentRepository.FindByReference(PaymentRef);
        }

        public Payment Add(Payment payment)
        {
            return paymentRepository.Add(payment);
        }

        public Payment Update(Payment payment)
        {
            return paymentRepository.Update(payment);
        }

        public void Delete(int id)
        {
            paymentRepository.Delete(id);
        }

        public List<Payment> GetAll()
        {
            return paymentRepository.GetAll();

        }

        public bool Exists(int id)
        {
            return paymentRepository.Exists(id);
        }
    }
}
