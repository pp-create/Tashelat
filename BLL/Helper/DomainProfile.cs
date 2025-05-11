using AutoMapper;
using DAL;
using DAL.Entities;
using DAL.ViewModel;

namespace BLL.Helper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            #region courses
            CreateMap<Import, ImportViewModel>().ReverseMap();
            CreateMap<Homepage, HomepageViewModel>().ReverseMap();
            CreateMap<Services, ServicesVM>().ReverseMap();
            CreateMap<Questions, QuestionsVM>().ReverseMap();
            CreateMap<Users, UserVM>().ReverseMap();

            #endregion
            #region Reading
            CreateMap<Reading,ReadingVM>().ReverseMap(); CreateMap<BookFile, filebbookViewModel>().ReverseMap();
            CreateMap<MassagerUesrs,MassagerUesrsVM>().ReverseMap(); CreateMap<Request, RequestVM>().ReverseMap();
            #endregion       
            #region AboutVM
            CreateMap<About, AboutVM>().ReverseMap(); CreateMap<Contact, ContactVM>().ReverseMap();   CreateMap<Repliescostomer, RepliescostomerVm>().ReverseMap();
            #endregion





        }
    }
}
