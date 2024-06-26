﻿namespace RealEstate.GlobalConstants
{
    public static class EntityValidation
    {
        public static class SalesCategoryValidation
        {
            public const int NAME_MAX_LENGTH = 10;
        }
        public static class PropertyCategoryValidation
        {
            public const int NAME_MAX_LENGTH = 30;
        }
        public static class PropertyValidation
        {
            public const int NAME_MAX_LENGTH = 60;
            public const int NAME_MIN_LENGTH = 5;

            public const int CITY_MAX_LENGTH = 57;
            public const int ADDRESS_MAX_LENGTH = 110;

            public const int DESCRIPTION_MAX_LENGTH = 800;
        }
    }
}
