using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract
{
    public interface ITourniquetService
    {
        IResult Entry(Tourniquet tourniquet);
        IResult Exit(Tourniquet tourniquet);
        IDataResult<List<Tourniquet>> GetAll();
        IDataResult<Tourniquet> GetByTourniquet(int id);
        IDataResult<TourniquetPerson> GetTourniquetByPerson(int personId);
        IDataResult<List<Tourniquet>> GetDayTourniquet(DateTime dateTime);
        IDataResult<List<Tourniquet>> GetMonthTourniquet(DateTime dateTime);
    }
}