

namespace DO;



    // מייצג לקוח עם הפרטים שלו.
    public record Customer
            (int Id,//מזהה ייחודי עבור הלקוח
            String? NameCustomer,//שם הלקוח
            String? Address,//כתובת הלקוח.
            String? Phone //מספר הטלפון של הלקוח
            )
    {

        public Customer() : this(100, null, null, null)
        {
        }
    }

