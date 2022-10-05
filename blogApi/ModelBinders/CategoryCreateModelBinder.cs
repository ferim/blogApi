using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.DataTransferObjects;

namespace blogApi.ModelBinders
{
    public class CategoryCreateModelBinder : IModelBinder
    {
        //logger
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var request = bindingContext.HttpContext.Request;

            if (request == null)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;

            }
            var model = SetValuesForModel(bindingContext);

            bindingContext.Result = ModelBindingResult.Success(model);

            return Task.CompletedTask;

        }

        private static CreateCategoryDto SetValuesForModel(ModelBindingContext bindingContext)
        {
            var dtoModel = new CreateCategoryDto();
            var properties = typeof(CreateCategoryDto).GetProperties();
            using (var reader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                var body = reader.ReadToEndAsync();
                var bodyResult = JsonConvert.DeserializeObject<JObject>(body.Result);

                foreach (var property in properties)
                {
                   // var propertyValue = bindingContext.ValueProvider.GetValue(property.Name);

                    //property.SetValue(dtoModel, propertyValue.FirstValue);
                    property.SetValue(dtoModel, bodyResult[property.Name.ToLower()].ToString());
                }
            }
            return dtoModel;
        }
    }
}
