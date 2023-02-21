using UserAPI.Models;

namespace UserAPI.Repository
{
    // Ignore this Repo (as of 21/2)
    public interface ICreditCardRepository
    {
        CreditCard GetCreditCard(string email);
        void SaveCreditCard(CreditCard card);
        void UpdateCreditCard(string email, CreditCard card);
        void DeleteCreditCard(string email);
    }
}
