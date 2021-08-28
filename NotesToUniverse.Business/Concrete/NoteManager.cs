using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.DataAccess.Abstract;
using NotesToUniverse.Entities;

namespace NotesToUniverse.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }


        public List<Note> GetAllNote()
        {
            return _noteDal.List();
        }
    }
}
