using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NubimetricsChallenge.Models
{
    public class Busqueda
    {
        public string site_id { get; set; }
        public string country_default_time_zone { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public List<Result> results { get; set; }
        public Sort sort { get; set; }
        public List<Available_Sorts> available_sorts { get; set; }
        public List<Filter> filters { get; set; }
        public List<Available_Filters> available_filters { get; set; }
    }

    public class BusquedaChallenge
    {
        public BusquedaChallenge(Busqueda busqueda)
        {
            this.site_id = busqueda.site_id;
            this.country_default_time_zone = busqueda.country_default_time_zone;
            this.query = busqueda.query;
            this.paging = busqueda.paging;
            this.sort = busqueda.sort;
            this.available_sorts = busqueda.available_sorts;
            this.filters = busqueda.filters;
            this.available_filters = busqueda.available_filters;
            this.results = new List<ResultChallenge>();
            foreach(Result result in busqueda.results)
            {
                this.results.Add(new ResultChallenge(result));
            }
        }
        public string site_id { get; set; }
        public string country_default_time_zone { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public List<ResultChallenge> results { get; set; }
        public Sort sort { get; set; }
        public List<Available_Sorts> available_sorts { get; set; }
        public List<Filter> filters { get; set; }
        public List<Available_Filters> available_filters { get; set; }
    }

    public class Paging
    {
        public int total { get; set; }
        public int primary_results { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }

    public class Sort
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public Seller seller { get; set; }
        public float price { get; set; }
        public Prices prices { get; set; }
        public object sale_price { get; set; }
        public string currency_id { get; set; }
        public int available_quantity { get; set; }
        public int sold_quantity { get; set; }
        public string buying_mode { get; set; }
        public string listing_type_id { get; set; }
        public DateTime stop_time { get; set; }
        public string condition { get; set; }
        public string permalink { get; set; }
        public string thumbnail { get; set; }
        public string thumbnail_id { get; set; }
        public bool accepts_mercadopago { get; set; }
        public Installments installments { get; set; }
        public Address address { get; set; }
        public Shipping shipping { get; set; }
        public Seller_Address seller_address { get; set; }
        public List<Attribute> attributes { get; set; }
        public Differential_Pricing differential_pricing { get; set; }
        public int? original_price { get; set; }
        public string category_id { get; set; }
        public int? official_store_id { get; set; }
        public string domain_id { get; set; }
        public string catalog_product_id { get; set; }
        public List<string> tags { get; set; }
        public bool catalog_listing { get; set; }
        public bool use_thumbnail_id { get; set; }
        public object offer_score { get; set; }
        public object offer_share { get; set; }
        public object match_score { get; set; }
        public object winner_item_id { get; set; }
        public object melicoin { get; set; }
        public int order_backend { get; set; }
    }

    public class ResultChallenge
    {
        public ResultChallenge(Result result)
        {
            this.id = result.id;
            this.site_id = result.site_id;
            this.title = result.title;
            this.seller_id = result.seller.id;
            this.price = result.price;
            this.permalink = result.permalink;
        }
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public int seller_id { get; set; }
        public float price { get; set; }
        public string permalink { get; set; }
    }

    public class Seller
    {
        public int id { get; set; }
        public string permalink { get; set; }
        public DateTime registration_date { get; set; }
        public bool car_dealer { get; set; }
        public bool real_estate_agency { get; set; }
        public List<string> tags { get; set; }
        public Seller_Reputation seller_reputation { get; set; }
        public Eshop eshop { get; set; }
    }

    public class Seller_Reputation
    {
        public string power_seller_status { get; set; }
        public string level_id { get; set; }
        public Metrics metrics { get; set; }
        public Transactions transactions { get; set; }
    }

    public class Metrics
    {
        public Cancellations cancellations { get; set; }
        public Claims claims { get; set; }
        public Delayed_Handling_Time delayed_handling_time { get; set; }
        public Sales sales { get; set; }
    }

    public class Cancellations
    {
        public string period { get; set; }
        public float rate { get; set; }
        public int value { get; set; }
    }

    public class Claims
    {
        public string period { get; set; }
        public float rate { get; set; }
        public int value { get; set; }
    }

    public class Delayed_Handling_Time
    {
        public string period { get; set; }
        public float rate { get; set; }
        public int value { get; set; }
    }

    public class Sales
    {
        public string period { get; set; }
        public int completed { get; set; }
    }

    public class Transactions
    {
        public int canceled { get; set; }
        public string period { get; set; }
        public int total { get; set; }
        public Ratings ratings { get; set; }
        public int completed { get; set; }
    }

    public class Ratings
    {
        public float negative { get; set; }
        public float neutral { get; set; }
        public float positive { get; set; }
    }

    public class Eshop
    {
        public int seller { get; set; }
        public object eshop_rubro { get; set; }
        public int eshop_id { get; set; }
        public string nick_name { get; set; }
        public string site_id { get; set; }
        public string eshop_logo_url { get; set; }
        public int eshop_status_id { get; set; }
        public int eshop_experience { get; set; }
        public List<object> eshop_locations { get; set; }
    }

    public class Prices
    {
        public string id { get; set; }
        public List<Price> prices { get; set; }
        public Presentation presentation { get; set; }
        public List<object> payment_method_prices { get; set; }
        public List<Reference_Prices> reference_prices { get; set; }
        public List<object> purchase_discounts { get; set; }
    }

    public class Presentation
    {
        public string display_currency { get; set; }
    }

    public class Price
    {
        public string id { get; set; }
        public string type { get; set; }
        public float amount { get; set; }
        public int? regular_amount { get; set; }
        public string currency_id { get; set; }
        public DateTime last_updated { get; set; }
        public Conditions conditions { get; set; }
        public string exchange_rate_context { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Conditions
    {
        public List<string> context_restrictions { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public bool eligible { get; set; }
    }

    public class Metadata
    {
        public string promotion_id { get; set; }
        public string promotion_type { get; set; }
        public string campaign_id { get; set; }
        public float discount_meli_amount { get; set; }
        public int campaign_discount_percentage { get; set; }
        public DateTime campaign_end_date { get; set; }
        public float order_item_price { get; set; }
    }

    public class Reference_Prices
    {
        public string id { get; set; }
        public string type { get; set; }
        public Conditions1 conditions { get; set; }
        public float amount { get; set; }
        public string currency_id { get; set; }
        public string exchange_rate_context { get; set; }
        public List<object> tags { get; set; }
        public DateTime last_updated { get; set; }
    }

    public class Conditions1
    {
        public List<string> context_restrictions { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public bool eligible { get; set; }
    }

    public class Installments
    {
        public int quantity { get; set; }
        public float amount { get; set; }
        public float rate { get; set; }
        public string currency_id { get; set; }
    }

    public class Address
    {
        public string state_id { get; set; }
        public string state_name { get; set; }
        public string city_id { get; set; }
        public string city_name { get; set; }
    }

    public class Shipping
    {
        public bool free_shipping { get; set; }
        public string mode { get; set; }
        public List<string> tags { get; set; }
        public string logistic_type { get; set; }
        public bool store_pick_up { get; set; }
    }

    public class Seller_Address
    {
        public string id { get; set; }
        public string comment { get; set; }
        public string address_line { get; set; }
        public string zip_code { get; set; }
        public Country country { get; set; }
        public State state { get; set; }
        public City city { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class State
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Differential_Pricing
    {
        public int id { get; set; }
    }

    public class Attribute
    {
        public string value_name { get; set; }
        public List<Value> values { get; set; }
        public string attribute_group_id { get; set; }
        public string id { get; set; }
        public string value_id { get; set; }
        public string attribute_group_name { get; set; }
        public long source { get; set; }
        public string name { get; set; }
        public Value_Struct value_struct { get; set; }
    }

    public class Value_Struct
    {
        public string unit { get; set; }
        public int number { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string name { get; set; }
        public Struct _struct { get; set; }
        public long source { get; set; }
    }

    public class Struct
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class Available_Sorts
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Filter
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<Value1> values { get; set; }
    }

    public class Value1
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Path_From_Root> path_from_root { get; set; }
    }

    public class Path_From_Root
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Available_Filters
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<Value2> values { get; set; }
    }

    public class Value2
    {
        public string id { get; set; }
        public string name { get; set; }
        public int results { get; set; }
    }
}
