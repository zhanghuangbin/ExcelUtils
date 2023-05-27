using System;



namespace com.huangbin.excel.impl
{

    internal struct MappingInfoHolder
    {
        internal int idx;
        internal ExcelMapping mapping;

    }
    public class AttributeParseHandler<T> : AbstracrDefaultExcelParseHandler<T>
    {

        public AttributeParseHandler(Type modelType) : base(modelType) {
            
        }

        protected override ApplyAction<T> CreateParseRule(int i, string title)
        {
            return (val, data, errors)=> { };
        }
    }




}
