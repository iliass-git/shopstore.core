using ShopStore.DbContext.Entities;
using ShopStore.Mappers.Interfaces;
namespace ShopStore.Mapper;

public class UserInfoMapper: IUserInfoMapper {

    public UserInfoEntity MapToUserInfoEntity(UserInfo userInfo){
        return new UserInfoEntity{
            Id = userInfo.Id,
            UserName = userInfo.UserName,
            Email = userInfo.Email,
            Password = userInfo.Password,
            CreatedDate = userInfo.CreatedDate,
        };
    }
    public UserInfo MapToUserInfo(UserInfoEntity userInfoEntity){
        return new UserInfo{
            Id = userInfoEntity.Id,
            Email = userInfoEntity.Email,
            Password = userInfoEntity.Password,
            UserName = userInfoEntity.UserName,
            CreatedDate = userInfoEntity.CreatedDate,
        };
    }

    public IList<UserInfo> MapToUserInfos(IList<UserInfoEntity> userInfoEntities){
        IList<UserInfo> userInfos = new List<UserInfo>();
        foreach(UserInfoEntity userInfoEntity in userInfoEntities){
            userInfos.Add(MapToUserInfo(userInfoEntity));
        }
        return userInfos;
    }

    public IList<UserInfoEntity> MapToUserInfoEntities(IList<UserInfo> userInfos){
        IList<UserInfoEntity> userInfoEntities = new List<UserInfoEntity>();
        foreach(UserInfo userInfo in userInfos){
            userInfoEntities.Add(MapToUserInfoEntity(userInfo));
        }
        return userInfoEntities;
    }

}