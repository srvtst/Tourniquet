using Entities.Concrate;
using Entities.Dto;

namespace DataAccess.Abstract
{
    public interface ITourniquetDal
    {
        void Entry(Tourniquet tourniquet);
        void Exit(Tourniquet tourniquet);
        Tourniquet GetByTourniquet(int id);
        List<Tourniquet> GetAll();
        TourniquetPerson GetTourniquetByPerson(int personId);
        List<Tourniquet> GetDayTourniquet(DateTime dateTime);
        List<Tourniquet> GetMonthTourniquet(DateTime dateTime);
    }
}