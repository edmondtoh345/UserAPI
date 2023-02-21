using MongoDB.Driver;
using UserAPI.Models;

namespace UserAPI.Repository
{
    // Ignore this Repo (as of 21/2)
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly DataContext db;
        public CreditCardRepository(DataContext db)
        {
            this.db = db;
        }

        public void DeleteCreditCard(string email)
        {
            db.CreditCards.DeleteOne(x => x.Email == email);
        }

        public CreditCard GetCreditCard(string email)
        {
            return db.CreditCards.Find(x => x.Email == email).FirstOrDefault();
        }

        public void SaveCreditCard(CreditCard card)
        {
            db.CreditCards.InsertOne(card);
        }

        public void UpdateCreditCard(string email, CreditCard card)
        {
            var filter = Builders<CreditCard>.Filter.Where(x => x.Email == email);
            var update = Builders<CreditCard>.Update
                .Set(x => x.CreditCardName, card.CreditCardName)
                .Set(x => x.CreditCardNumber, card.CreditCardNumber)
                .Set(x => x.CreditCardExpiryDate, card.CreditCardExpiryDate);
            db.CreditCards.UpdateOne(filter, update);
        }
    }
}
