using ShopStore.DbContext.Entities;
namespace ShopStore.Mappers.Interfaces;

public interface IUserInfoMapper {
    UserInfoEntity MapToUserInfoEntity(UserInfo userInfo);
    UserInfo MapToUserInfo(UserInfoEntity userInfoEntity);
    IList<UserInfo> MapToUserInfos(IList<UserInfoEntity> userInfoEntities);
    IList<UserInfoEntity> MapToUserInfoEntities(IList<UserInfo> userInfos);
}
