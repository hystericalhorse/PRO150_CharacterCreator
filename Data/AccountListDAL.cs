using CharacterCreator.Interfaces;
using CharacterCreator.Models;

namespace CharacterCreator.Data {
	public class AccountListDAL : IDataAccessLayer {
		private AppDbContext DB;
		public AccountListDAL(AppDbContext indb) {
			DB = indb;
		}


	}
}