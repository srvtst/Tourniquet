using Entities.Concrate;
using Entities.Dto;

namespace Business.Abstract
{
    public interface ITourniquetService
    {
        void Entry(Tourniquet tourniquet);
        void Exit(Tourniquet tourniquet);
        List<Tourniquet> GetAll();
        Tourniquet GetByTourniquet(int id);
        TourniquetPerson GetTourniquetByPerson(int personId);
        List<Tourniquet> GetDayTourniquet(DateTime dateTime);
        List<Tourniquet> GetMonthTourniquet(DateTime dateTime);
    }
}