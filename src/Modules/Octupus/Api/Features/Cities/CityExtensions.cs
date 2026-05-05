using Octupus.Api.Features.Addresses;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Cities;

public partial class City
{
    public static Result<City> Create(string name, string town, string state,
        string? zipCode = null) =>
        Result
            .Create(new City()
            {
                Name = name,
                ZipCode = zipCode,
                Town = town,
                State = state
            });

    public Result Update(string? name = null, string? town = null,
        string? zipCode = null, string? state = null) =>
        Result
            .Assign(this, name.IsNullEmptyOrWhiteSpace(), x => x.Name = name!)
            .Assign(this, town.IsNullEmptyOrWhiteSpace(), x => x.Town = town!)
            .Assign(this, zipCode.IsNullEmptyOrWhiteSpace(), x => x.ZipCode = zipCode)
            .Assign(this, state.IsNullEmptyOrWhiteSpace(), x => x.State = state!);


    public Result AddAddress(Address address) =>
        Result
            .Check(this, x => x.Addresses.Contains(address), ErrorCodes.OctupusApi.CityAddressAlreadyExists)
            .Bind(this, x => x.Addresses.Add(address));

    public Result RemoveAddress(Address address) =>
        Result
            .Check(this, x => x.Addresses.Contains(address), ErrorCodes.OctupusApi.CityAddressDoesNotExists)
            .Bind(this, x => x.Addresses.Remove(address));
}
