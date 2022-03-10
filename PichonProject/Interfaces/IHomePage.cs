using PichonProject.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Interfaces
{
    public interface IHomePage : IPages
    {
        HomePage goEquipmentPage();
        HomePage clickMaterialsIcon();
        HomePage addNewMaterial();
        HomePage goAnyPage(string material);
        void validateSuccessfulAddressing();
        HomePage addNewEquipment();
        void validateSuccessfulInsertion();
        HomePage editDataEquipment();
        void deleteDataEquitment();
        void LogOut();

    }
}
