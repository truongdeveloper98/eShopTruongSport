using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTruongSport.ViewModels.Common
{
    public  class ApiSuccessResult<T> : ApiResult<T>
    {
        public  ApiSuccessResult(T reslutObj)
        {
            IsSuccessed = true;
            ObjResult = reslutObj;
        }
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}
