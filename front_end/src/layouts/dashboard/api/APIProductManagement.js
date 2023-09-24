import { request } from "helper/Request.helper";
// import

export default class APIProductManagerment {
  static eventDetail(eventId) {
    return request({
      method: "GET",
      url: URL_API_ORGANIZER_MANAGEMENT + "/event-detail/" + eventId,
    });
  }
}
