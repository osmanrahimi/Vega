using AutoMapper;
using System.Linq;
using vega.Models;
using vega.Models.Resources;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(v => v.Contact, opt => opt.MapFrom(r => new ContactResource { Name = r.ContactName, Phone = r.ContactPhone, Email = r.ContactEmail }))
                .ForMember(v => v.Features, opt => opt.MapFrom(vf => vf.Features.Select(item => item.FeatureId)));

            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr=>vr.Make,opt=>opt.MapFrom(i=>i.Model.Make))
                .ForMember(v => v.Contact, opt => opt.MapFrom(r => new ContactResource { Name = r.ContactName, Phone = r.ContactPhone, Email = r.ContactEmail }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf =>new KeyValuePairResource { Id=vf.FeatureId,Name=vf.Feature.Name})));
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    var removedItems = v.Features.Where(item => !vr.Features.Contains(item.FeatureId));
                    foreach (var item in removedItems)
                        v.Features.Remove(item);

                    var AddedItems = vr.Features.Where(i => !v.Features.Any(f => f.FeatureId == i));
                    foreach (var id in AddedItems)
                        v.Features.Add(new VehicleFeature { FeatureId = id });

                });



        }
    }
}
