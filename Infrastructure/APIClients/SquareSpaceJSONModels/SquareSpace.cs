using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.APIClients.SquareSpaceJSONModels
{
	public class SiteStatus
	{
	}

	public class Location
	{
		public double mapZoom { get; set; }
		public double mapLat { get; set; }
		public double mapLng { get; set; }
		public string addressTitle { get; set; }
		public string addressLine1 { get; set; }
		public string addressLine2 { get; set; }
		public string addressCountry { get; set; }
	}

	public class ShareButtonOptions
	{
		public bool _3 { get; set; }
		public bool _2 { get; set; }
		public bool _4 { get; set; }
		public bool _8 { get; set; }
		public bool _7 { get; set; }
		public bool _6 { get; set; }
		public bool _1 { get; set; }
	}

	public class SocialAccount
	{
		public int serviceId { get; set; }
		public object addedOn { get; set; }
		public string profileUrl { get; set; }
		public bool iconEnabled { get; set; }
		public string serviceName { get; set; }
		public string screenname { get; set; }
	}

	public class CaptchaSettings
	{
		public bool enabledForDonations { get; set; }
	}

	public class Website
	{
		public string id { get; set; }
		public string identifier { get; set; }
		public int websiteType { get; set; }
		public long contentModifiedOn { get; set; }
		public bool cloneable { get; set; }
		public bool hasBeenCloneable { get; set; }
		public SiteStatus siteStatus { get; set; }
		public string language { get; set; }
		public string timeZone { get; set; }
		public int machineTimeZoneOffset { get; set; }
		public int timeZoneOffset { get; set; }
		public string timeZoneAbbr { get; set; }
		public string siteTitle { get; set; }
		public string siteDescription { get; set; }
		public Location location { get; set; }
		public string logoImageId { get; set; }
		public string mobileLogoImageId { get; set; }
		public ShareButtonOptions shareButtonOptions { get; set; }
		public string logoImageUrl { get; set; }
		public string mobileLogoImageUrl { get; set; }
		public string authenticUrl { get; set; }
		public string internalUrl { get; set; }
		public string baseUrl { get; set; }
		public string primaryDomain { get; set; }
		public int sslSetting { get; set; }
		public bool isHstsEnabled { get; set; }
		public List<SocialAccount> socialAccounts { get; set; }
		public string typekitId { get; set; }
		public bool statsMigrated { get; set; }
		public bool imageMetadataProcessingEnabled { get; set; }
		public string screenshotId { get; set; }
		public CaptchaSettings captchaSettings { get; set; }
		public bool showOwnerLogin { get; set; }
	}

	public class MobileInfoBarSettings
	{
		public int style { get; set; }
		public bool isContactEmailEnabled { get; set; }
		public bool isContactPhoneNumberEnabled { get; set; }
		public bool isLocationEnabled { get; set; }
		public bool isBusinessHoursEnabled { get; set; }
	}

	public class AnnouncementBarSettings
	{
		public int style { get; set; }
	}

	public class PopupOverlaySettings
	{
		public int style { get; set; }
		public List<object> enabledPages { get; set; }
	}

	public class Ranx
	{
		public int from { get; set; }
		public int to { get; set; }
	}

	public class Monday
	{
		public string text { get; set; }
		public List<Ranx> ranges { get; set; }
	}

	public class Tuesday
	{
		public string text { get; set; }
		public List<Ranx> ranges { get; set; }
	}

	public class Wednesday
	{
		public string text { get; set; }
		public List<Ranx> ranges { get; set; }
	}

	public class Thursday
	{
		public string text { get; set; }
		public List<Ranx> ranges { get; set; }
	}

	public class Friday
	{
		public string text { get; set; }
		public List<Ranx> ranges { get; set; }
	}

	public class Saturday
	{
		public string text { get; set; }
		public List<Ranx> ranges { get; set; }
	}

	public class Sunday
	{
		public string text { get; set; }
		public List<Ranx> ranges { get; set; }
	}

	public class BusinessHours
	{
		public Monday monday { get; set; }
		public Tuesday tuesday { get; set; }
		public Wednesday wednesday { get; set; }
		public Thursday thursday { get; set; }
		public Friday friday { get; set; }
		public Saturday saturday { get; set; }
		public Sunday sunday { get; set; }
	}

	public class MerchandisingSettings
	{
		public bool scarcityEnabledOnProductItems { get; set; }
		public bool scarcityEnabledOnProductBlocks { get; set; }
		public string scarcityMessageType { get; set; }
		public int scarcityThreshold { get; set; }
		public bool multipleQuantityAllowedForServices { get; set; }
		public bool restockNotificationsEnabled { get; set; }
		public bool restockNotificationsMailingListSignUpEnabled { get; set; }
		public bool relatedProductsEnabled { get; set; }
		public string relatedProductsOrdering { get; set; }
		public bool soldOutVariantsDropdownDisabled { get; set; }
		public bool productComposerOptedIn { get; set; }
		public bool productComposerABTestOptedOut { get; set; }
		public bool productReviewsEnabled { get; set; }
		public bool displayNativeProductReviewsEnabled { get; set; }
		public bool displayImportedProductReviewsEnabled { get; set; }
		public bool productReviewsMerchantEmailEnabled { get; set; }
		public bool hasOptedToCollectNativeReviews { get; set; }
	}

	public class StoreSettings
	{
		public object returnPolicy { get; set; }
		public object termsOfService { get; set; }
		public object privacyPolicy { get; set; }
		public bool expressCheckout { get; set; }
		public string continueShoppingLinkUrl { get; set; }
		public bool useLightCart { get; set; }
		public bool showNoteField { get; set; }
		public string shippingCountryDefaultValue { get; set; }
		public bool billToShippingDefaultValue { get; set; }
		public bool showShippingPhoneNumber { get; set; }
		public bool isShippingPhoneRequired { get; set; }
		public bool showBillingPhoneNumber { get; set; }
		public bool isBillingPhoneRequired { get; set; }
		public List<string> currenciesSupported { get; set; }
		public string defaultCurrency { get; set; }
		public string selectedCurrency { get; set; }
		public int measurementStandard { get; set; }
		public bool showCustomCheckoutForm { get; set; }
		public bool checkoutPageMarketingOptInEnabled { get; set; }
		public bool enableMailingListOptInByDefault { get; set; }
		public bool sameAsRetailLocation { get; set; }
		public MerchandisingSettings merchandisingSettings { get; set; }
		public bool isLive { get; set; }
		public bool multipleQuantityAllowedForServices { get; set; }
	}

	public class PinterestOverlayOptions
	{
		public string mode { get; set; }
	}

	public class UserAccountsSettings
	{
		public bool loginAllowed { get; set; }
		public bool signupAllowed { get; set; }
	}

	public class WebsiteSettings
	{
		public string id { get; set; }
		public string websiteId { get; set; }
		public List<object> subjects { get; set; }
		public string country { get; set; }
		public string state { get; set; }
		public bool simpleLikingEnabled { get; set; }
		public MobileInfoBarSettings mobileInfoBarSettings { get; set; }
		public AnnouncementBarSettings announcementBarSettings { get; set; }
		public PopupOverlaySettings popupOverlaySettings { get; set; }
		public bool commentLikesAllowed { get; set; }
		public bool commentAnonAllowed { get; set; }
		public bool commentThreaded { get; set; }
		public bool commentApprovalRequired { get; set; }
		public bool commentAvatarsOn { get; set; }
		public int commentSortType { get; set; }
		public int commentFlagThreshold { get; set; }
		public bool commentFlagsAllowed { get; set; }
		public bool commentEnableByDefault { get; set; }
		public int commentDisableAfterDaysDefault { get; set; }
		public string disqusShortname { get; set; }
		public string collectionTitleFormat { get; set; }
		public string itemTitleFormat { get; set; }
		public bool commentsEnabled { get; set; }
		public bool uiComponentRegistrationsFlag { get; set; }
		public bool scriptRegistrationsFlag { get; set; }
		public BusinessHours businessHours { get; set; }
		public StoreSettings storeSettings { get; set; }
		public bool useEscapeKeyToLogin { get; set; }
		public int ssBadgeType { get; set; }
		public int ssBadgePosition { get; set; }
		public int ssBadgeVisibility { get; set; }
		public int ssBadgeDevices { get; set; }
		public PinterestOverlayOptions pinterestOverlayOptions { get; set; }
		public bool ampEnabled { get; set; }
		public bool seoHidden { get; set; }
		public UserAccountsSettings userAccountsSettings { get; set; }
		public string contactEmail { get; set; }
		public string contactPhoneNumber { get; set; }
	}

	public class Collection
	{
		public string id { get; set; }
		public string websiteId { get; set; }
		public bool enabled { get; set; }
		public bool starred { get; set; }
		public int type { get; set; }
		public int ordering { get; set; }
		public string title { get; set; }
		public string navigationTitle { get; set; }
		public string urlId { get; set; }
		public int itemCount { get; set; }
		public long updatedOn { get; set; }
		public string description { get; set; }
		public int pageSize { get; set; }
		public bool folder { get; set; }
		public bool dropdown { get; set; }
		public List<object> tags { get; set; }
		public List<object> categories { get; set; }
		public bool homepage { get; set; }
		public string typeName { get; set; }
		public string regionName { get; set; }
		public bool synchronizing { get; set; }
		public bool categoryPagesSeoHidden { get; set; }
		public bool tagPagesSeoHidden { get; set; }
		public string fullUrl { get; set; }
		public string typeLabel { get; set; }
		public bool passwordProtected { get; set; }
		public int pagePermissionType { get; set; }
	}

	public class ShippingLocation
	{
	}

	public class ShoppingCart
	{
		public string websiteId { get; set; }
		public long created { get; set; }
		public List<object> entries { get; set; }
		public ShippingLocation shippingLocation { get; set; }
		public List<object> taxLineItems { get; set; }
		public List<object> coupons { get; set; }
		public List<object> promoCodes { get; set; }
		public List<object> appliedGiftCards { get; set; }
		public int cartType { get; set; }
		public List<object> validCoupons { get; set; }
		public List<object> invalidCoupons { get; set; }
		public int subtotalCents { get; set; }
		public int taxCents { get; set; }
		public int shippingCostCents { get; set; }
		public int discountCents { get; set; }
		public int giftCardRedemptionTotalCents { get; set; }
		public int grandTotalCents { get; set; }
		public int amountDueCents { get; set; }
		public int totalQuantity { get; set; }
		public bool purelyDigital { get; set; }
		public bool hasDigital { get; set; }
		public bool requiresShipping { get; set; }
		public List<object> shippingOptions { get; set; }
	}

	public class ShareButtons
	{
		public bool twitter { get; set; }
		public bool facebook { get; set; }
		public bool reddit { get; set; }
		public bool tumblr { get; set; }
		public bool google { get; set; }
		public bool pinterest { get; set; }
		public bool linkedin { get; set; }
	}

	public class ProductPriceFromMonthlyText
	{
		public string one { get; set; }
		public string other { get; set; }
	}

	public class ProductPriceFromWeeklyText
	{
		public string one { get; set; }
		public string other { get; set; }
	}

	public class ProductPricePerMonth
	{
		public string one { get; set; }
		public string other { get; set; }
	}

	public class ProductPricePerWeek
	{
		public string one { get; set; }
		public string other { get; set; }
	}

	public class LocalizedStrings
	{
		public string account { get; set; }
		public string all { get; set; }
		public string allProducts { get; set; }
		public string back { get; set; }
		public string backToAllEvents { get; set; }
		public string category { get; set; }
		public string close { get; set; }
		public string closeMenu { get; set; }
		public string currentPage { get; set; }
		public string earlierEvent { get; set; }
		public string filteringByBoth { get; set; }
		public string filteringByOne { get; set; }
		public string folder { get; set; }
		public string gallery { get; set; }
		public string galleryThumbnails { get; set; }
		public string giftCardVariantSelectText { get; set; }
		public string giftCardValueDisplayText { get; set; }
		public string googleCalendar { get; set; }
		public string iCal { get; set; }
		public string languageFlagIcon { get; set; }
		public string laterEvent { get; set; }
		public string listOfCategories { get; set; }
		public string login { get; set; }
		public string map { get; set; }
		public string newerPosts { get; set; }
		public string next { get; set; }
		public string nextPage { get; set; }
		public string noUpcomingEvents { get; set; }
		public string olderPosts { get; set; }
		public string openMenu { get; set; }
		public string postedIn { get; set; }
		public string prev { get; set; }
		public string previous { get; set; }
		public string previousPage { get; set; }
		public string productAddToCartText { get; set; }
		public string productAnswerMapAgree { get; set; }
		public string productAnswerMapDisagree { get; set; }
		public string productAnswerMapNeutral { get; set; }
		public string productAnswerMapStronglyDisagree { get; set; }
		public string productAnswerStronglyAgree { get; set; }
		public string productPrice__multiplePrices__1Monthly__indefinite { get; set; }
		public string productPrice__multiplePrices__1Monthly__limited__1Years { get; set; }
		public string productPrice__multiplePrices__1Monthly__limited__nMonths { get; set; }
		public string productPrice__multiplePrices__1Monthly__limited__nYears { get; set; }
		public string productPrice__multiplePrices__1Weekly__indefinite { get; set; }
		public string productPrice__multiplePrices__1Weekly__limited__1Months { get; set; }
		public string productPrice__multiplePrices__1Weekly__limited__1Years { get; set; }
		public string productPrice__multiplePrices__1Weekly__limited__nMonths { get; set; }
		public string productPrice__multiplePrices__1Weekly__limited__nWeeks { get; set; }
		public string productPrice__multiplePrices__1Weekly__limited__nYears { get; set; }
		public string productPrice__multiplePrices__nMonthly__indefinite { get; set; }
		public string productPrice__multiplePrices__nMonthly__limited__1Years { get; set; }
		public string productPrice__multiplePrices__nMonthly__limited__nMonths { get; set; }
		public string productPrice__multiplePrices__nMonthly__limited__nYears { get; set; }
		public string productPrice__multiplePrices__nWeekly__indefinite { get; set; }
		public string productPrice__multiplePrices__nWeekly__limited__1Months { get; set; }
		public string productPrice__multiplePrices__nWeekly__limited__1Years { get; set; }
		public string productPrice__multiplePrices__nWeekly__limited__nMonths { get; set; }
		public string productPrice__multiplePrices__nWeekly__limited__nWeeks { get; set; }
		public string productPrice__multiplePrices__nWeekly__limited__nYears { get; set; }
		public string productPrice__singlePrice__1Monthly__indefinite { get; set; }
		public string productPrice__singlePrice__1Monthly__limited__1Years { get; set; }
		public string productPrice__singlePrice__1Monthly__limited__nMonths { get; set; }
		public string productPrice__singlePrice__1Monthly__limited__nYears { get; set; }
		public string productPrice__singlePrice__1Weekly__indefinite { get; set; }
		public string productPrice__singlePrice__1Weekly__limited__1Months { get; set; }
		public string productPrice__singlePrice__1Weekly__limited__1Years { get; set; }
		public string productPrice__singlePrice__1Weekly__limited__nMonths { get; set; }
		public string productPrice__singlePrice__1Weekly__limited__nWeeks { get; set; }
		public string productPrice__singlePrice__1Weekly__limited__nYears { get; set; }
		public string productPrice__singlePrice__nMonthly__indefinite { get; set; }
		public string productPrice__singlePrice__nMonthly__limited__1Years { get; set; }
		public string productPrice__singlePrice__nMonthly__limited__nMonths { get; set; }
		public string productPrice__singlePrice__nMonthly__limited__nYears { get; set; }
		public string productPrice__singlePrice__nWeekly__indefinite { get; set; }
		public string productPrice__singlePrice__nWeekly__limited__1Months { get; set; }
		public string productPrice__singlePrice__nWeekly__limited__1Years { get; set; }
		public string productPrice__singlePrice__nWeekly__limited__nMonths { get; set; }
		public string productPrice__singlePrice__nWeekly__limited__nWeeks { get; set; }
		public string productPrice__singlePrice__nWeekly__limited__nYears { get; set; }
		public ProductPriceFromMonthlyText productPriceFromMonthlyText { get; set; }
		public string productPriceFromText { get; set; }
		public ProductPriceFromWeeklyText productPriceFromWeeklyText { get; set; }
		public ProductPricePerMonth productPricePerMonth { get; set; }
		public ProductPricePerWeek productPricePerWeek { get; set; }
		public string productPriceUnavailable { get; set; }
		public string productQuantityInputLabel { get; set; }
		public string productQuickViewText { get; set; }
		public string productSaleText { get; set; }
		public string salePriceText { get; set; }
		public string originalPriceText { get; set; }
		public string productSoldOutText { get; set; }
		public string productSubscribeText { get; set; }
		public string productSummaryFormNoAnswerText { get; set; }
		public string productVariantSelectText { get; set; }
		public string readMore { get; set; }
		public string relatedProductsDefaultTitle { get; set; }
		public string skipToContent { get; set; }
		public string skipToVideos { get; set; }
		public string slideshowCurrentSlide { get; set; }
		public string slideshowNextSlide { get; set; }
		public string slideshowPreviousSlide { get; set; }
		public string slideshowSlide { get; set; }
		public string source { get; set; }
		public string tagged { get; set; }
		public string to { get; set; }
		public string untitledEvent { get; set; }
		public string videos { get; set; }
		public string view { get; set; }
		public string viewEvent { get; set; }
		public string viewFullItem { get; set; }
		public string viewFullsize { get; set; }
		public string writtenBy { get; set; }
		public string image { get; set; }
		public string carousel { get; set; }
		public string backgroundPause { get; set; }
		public string backgroundPlay { get; set; }
		public string videoMissingLabel { get; set; }
	}

	public class UserAccountsContext
	{
		public bool showSignInLink { get; set; }
	}

	public class Template
	{
		public bool mobileStylesEnabled { get; set; }
	}

	public class Uiextensions
	{

		public string ProductBadge { get; set; }


		public string ProductBody { get; set; }


		public string ProductBadgeMobile { get; set; }


		public string ProductBodyMobile { get; set; }

		public string ProductCollectionItem { get; set; }

		public bool ScriptsEnabled { get; set; }
	}

	public class MediaFocalPoint
	{
		public double x { get; set; }
		public double y { get; set; }
		public int source { get; set; }
	}

	public class ColorData
	{
		public string topLeftAverage { get; set; }
		public string topRightAverage { get; set; }
		public string bottomLeftAverage { get; set; }
		public string bottomRightAverage { get; set; }
		public string centerAverage { get; set; }
		public string suggestedBgColor { get; set; }
	}

	public class Author
	{
		public string id { get; set; }
		public string displayName { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string avatarUrl { get; set; }
		public string bio { get; set; }
		public string avatarAssetUrl { get; set; }
	}

	public class PushedServices
	{
	}

	public class PendingPushedServices
	{
	}

	public class SeoData
	{
		public string seoTitle { get; set; }
		public bool seoHidden { get; set; }
	}

	public class Item
	{
		public string id { get; set; }
		public string collectionId { get; set; }
		public int recordType { get; set; }
		public object addedOn { get; set; }
		public object updatedOn { get; set; }
		public int displayIndex { get; set; }
		public bool starred { get; set; }
		public bool passthrough { get; set; }
		public int workflowState { get; set; }
		public object publishOn { get; set; }
		public string authorId { get; set; }
		public string systemDataId { get; set; }
		public string systemDataVariants { get; set; }
		public string systemDataSourceType { get; set; }
		public string filename { get; set; }
		public MediaFocalPoint mediaFocalPoint { get; set; }
		public ColorData colorData { get; set; }
		public string urlId { get; set; }
		public string title { get; set; }
		public string sourceUrl { get; set; }
		public object body { get; set; }
		public string excerpt { get; set; }
		public int likeCount { get; set; }
		public int commentCount { get; set; }
		public int publicCommentCount { get; set; }
		public int commentState { get; set; }
		public bool unsaved { get; set; }
		public Author author { get; set; }
		public string fullUrl { get; set; }
		public string assetUrl { get; set; }
		public string contentType { get; set; }
		public List<object> items { get; set; }
		public PushedServices pushedServices { get; set; }
		public PendingPushedServices pendingPushedServices { get; set; }
		public SeoData seoData { get; set; }
		public string referencePageSectionsId { get; set; }
		public string recordTypeLabel { get; set; }
		public string originalSize { get; set; }
	}

	public class Root_SquareSpace
	{
		public Website website { get; set; }
		public WebsiteSettings websiteSettings { get; set; }
		public Collection collection { get; set; }
		public ShoppingCart shoppingCart { get; set; }
		public ShareButtons shareButtons { get; set; }
		public bool showCart { get; set; }
		public LocalizedStrings localizedStrings { get; set; }
		public UserAccountsContext userAccountsContext { get; set; }
		public Template template { get; set; }
		public Uiextensions uiextensions { get; set; }
		public bool empty { get; set; }
		public bool emptyFolder { get; set; }
		public bool calendarView { get; set; }
		public List<Item> items { get; set; }
	}
	public class RootJustItemsAndCollection
	{
		public List<Item> items { get; set; }

		public Collection collection { get; set; }
	}

}
