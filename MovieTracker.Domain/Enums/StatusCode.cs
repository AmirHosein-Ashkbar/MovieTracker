using Microsoft.AspNetCore.Http;

namespace MovieTracker.Domain.Enums;
public enum StatusCode
{
    // 1xx Informational
    //Continue = StatusCodes.Status100Continue,
    //SwitchingProtocols = StatusCodes.Status101SwitchingProtocols,
    //Processing = StatusCodes.Status102Processing,
    //EarlyHints = StatusCodes.Status103EarlyHints,

    // 2xx Success
    OK = StatusCodes.Status200OK,
    Created = StatusCodes.Status201Created,
    Accepted = StatusCodes.Status202Accepted,
    //NonAuthoritativeInformation = StatusCodes.Status203NonAuthoritative,
    NoContent = StatusCodes.Status204NoContent,
    //ResetContent = StatusCodes.Status205ResetContent,
    //PartialContent = StatusCodes.Status206PartialContent,
    //MultiStatus = StatusCodes.Status207MultiStatus,
    //AlreadyReported = StatusCodes.Status208AlreadyReported,
    //IMUsed = StatusCodes.Status226IMUsed,

    // 3xx Redirection
    //MultipleChoices = StatusCodes.Status300MultipleChoices,
    //MovedPermanently = StatusCodes.Status301MovedPermanently,
    //Found = StatusCodes.Status302Found,
    //SeeOther = StatusCodes.Status303SeeOther,
    //NotModified = StatusCodes.Status304NotModified,
    //UseProxy = StatusCodes.Status305UseProxy,
    //TemporaryRedirect = StatusCodes.Status307TemporaryRedirect,
    //PermanentRedirect = StatusCodes.Status308PermanentRedirect,

    // 4xx Client Errors
    BadRequest = StatusCodes.Status400BadRequest,
    Unauthorized = StatusCodes.Status401Unauthorized,
    //PaymentRequired = StatusCodes.Status402PaymentRequired,
    Forbidden = StatusCodes.Status403Forbidden,
    NotFound = StatusCodes.Status404NotFound,
    MethodNotAllowed = StatusCodes.Status405MethodNotAllowed,
    NotAcceptable = StatusCodes.Status406NotAcceptable,
    //ProxyAuthenticationRequired = StatusCodes.Status407ProxyAuthenticationRequired,
    //RequestTimeout = StatusCodes.Status408RequestTimeout,
    Conflict = StatusCodes.Status409Conflict,
    //Gone = StatusCodes.Status410Gone,
    //LengthRequired = StatusCodes.Status411LengthRequired,
    //PreconditionFailed = StatusCodes.Status412PreconditionFailed,
    //RequestEntityTooLarge = StatusCodes.Status413RequestEntityTooLarge,
    //RequestUriTooLong = StatusCodes.Status414RequestUriTooLong,
    //UnsupportedMediaType = StatusCodes.Status415UnsupportedMediaType,
    //RequestedRangeNotSatisfiable = StatusCodes.Status416RequestedRangeNotSatisfiable,
    //ExpectationFailed = StatusCodes.Status417ExpectationFailed,
    //ImATeapot = StatusCodes.Status418ImATeapot,
    //MisdirectedRequest = StatusCodes.Status421MisdirectedRequest,
    //UnprocessableEntity = StatusCodes.Status422UnprocessableEntity,
    //Locked = StatusCodes.Status423Locked,
    //FailedDependency = StatusCodes.Status424FailedDependency,
    //TooEarly = StatusCodes.Status425TooEarly,
    //UpgradeRequired = StatusCodes.Status426UpgradeRequired,
    //PreconditionRequired = StatusCodes.Status428PreconditionRequired,
    TooManyRequests = StatusCodes.Status429TooManyRequests,
    //RequestHeaderFieldsTooLarge = StatusCodes.Status431RequestHeaderFieldsTooLarge,
    //UnavailableForLegalReasons = StatusCodes.Status451UnavailableForLegalReasons,

    // 5xx Server Errors
    InternalServerError = StatusCodes.Status500InternalServerError,
    //NotImplemented = StatusCodes.Status501NotImplemented,
    BadGateway = StatusCodes.Status502BadGateway,
    //ServiceUnavailable = StatusCodes.Status503ServiceUnavailable,
    //GatewayTimeout = StatusCodes.Status504GatewayTimeout,
    //HttpVersionNotSupported = StatusCodes.Status505HttpVersionNotsupported,
    //VariantAlsoNegotiates = StatusCodes.Status506VariantAlsoNegotiates,
    //InsufficientStorage = StatusCodes.Status507InsufficientStorage,
    //LoopDetected = StatusCodes.Status508LoopDetected,
    //NotExtended = StatusCodes.Status510NotExtended,
    //NetworkAuthenticationRequired = StatusCodes.Status511NetworkAuthenticationRequired
}