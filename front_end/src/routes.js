/**
=========================================================
* Material Dashboard 2 React - v2.2.0
=========================================================

* Product Page: https://www.creative-tim.com/product/material-dashboard-react
* Copyright 2023 Creative Tim (https://www.creative-tim.com)

Coded by www.creative-tim.com

 =========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*/

/** 
  All of the routes for the Material Dashboard 2 React are added here,
  You can add a new route, customize the routes and delete the routes here.

  Once you add a new route on this file it will be visible automatically on
  the Sidenav.

  For adding a new route you can follow the existing routes in the routes array.
  1. The `type` key with the `collapse` value is used for a route.
  2. The `type` key with the `title` value is used for a title inside the Sidenav. 
  3. The `type` key with the `divider` value is used for a divider between Sidenav items.
  4. The `name` key is used for the name of the route on the Sidenav.
  5. The `key` key is used for the key of the route (It will help you with the key prop inside a loop).
  6. The `icon` key is used for the icon of the route on the Sidenav, you have to add a node.
  7. The `collapse` key is used for making a collapsible item on the Sidenav that has other routes
  inside (nested routes), you need to pass the nested routes inside an array as a value for the `collapse` key.
  8. The `route` key is used to store the route location which is used for the react router.
  9. The `href` key is used to store the external links location.
  10. The `title` key is only for the item with the type of `title` and its used for the title text on the Sidenav.
  10. The `component` key is used to store the component of its route.
*/


import BanHang from "./layouts/AdminBanHang/index";
import IndexManagementProduct from "./layouts/AdminManagementProduct/index";
import {
  faCartShopping,
  faUsers,
  faMoneyBill,
  faTags
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
// @mui icons
import Icon from "@mui/material/Icon";

const routes = [
  {
    type: "collapse",
    name: "Bán Hàng",
    key: "ban-hang",
    icon: <FontAwesomeIcon icon={faCartShopping} style={{color: "#ffffff",}} />,
    route: "/ban-hang",
    component: <BanHang />,
  },
  {
    type: "collapse",
    name: "Sản Phẩm",
    key: "san-pham",
    icon: <Icon fontSize="small">dashboard</Icon>,
    route: "/san-pham",
    component: <IndexManagementProduct />,
  },
  {
    type: "collapse",
    name: "Nhân Viên",
    key: "nhan-vien",
    icon: <FontAwesomeIcon icon={faUsers} style={{color: "#ffffff",}} />,
    route: "/nhan-vien",
    component: <BanHang />,
  },
  {
    type: "collapse",
    name: "Hóa Đơn",
    key: "hoa-don",
    icon: <FontAwesomeIcon icon={faMoneyBill} style={{color: "#ffffff",}} />,
    route: "/hoa-don",
    component: <BanHang />,
  },
  {
    type: "collapse",
    name: "Khuyến Mại",
    key: "khuyen-mai",
    icon: <FontAwesomeIcon icon={faTags} style={{color: "#ffffff",}} />,
    route: "/khuyen-mai",
    component: <BanHang />,
  },
  {
    type: "collapse",
    name: "Thống Kê",
    key: "thong-ke",
    icon: <FontAwesomeIcon icon={faCartShopping} style={{color: "#ffffff",}} />,
    route: "/thong-ke",
    component: <BanHang />,
  },
  // {
  //   type: "collapse",
  //   name: "Tables",
  //   key: "tables",
  //   icon: <Icon fontSize="small">table_view</Icon>,
  //   route: "/tables",
  //   component: <Tables />,
  // },
  // {
  //   type: "collapse",
  //   name: "Billing",
  //   key: "billing",
  //   icon: <Icon fontSize="small">receipt_long</Icon>,
  //   route: "/billing",
  //   component: <Billing />,
  // },
  // {
  //   type: "collapse",
  //   name: "RTL",
  //   key: "rtl",
  //   icon: <Icon fontSize="small">format_textdirection_r_to_l</Icon>,
  //   route: "/rtl",
  //   component: <RTL />,
  // },
  // {
  //   type: "collapse",
  //   name: "Notifications",
  //   key: "notifications",
  //   icon: <Icon fontSize="small">notifications</Icon>,
  //   route: "/notifications",
  //   component: <Notifications />,
  // },
  // {
  //   type: "collapse",
  //   name: "Profile",
  //   key: "profile",
  //   icon: <Icon fontSize="small">person</Icon>,
  //   route: "/profile",
  //   component: <Profile />,
  // },
  // {
  //   type: "collapse",
  //   name: "Sign In",
  //   key: "sign-in",
  //   icon: <Icon fontSize="small">login</Icon>,
  //   route: "/authentication/sign-in",
  //   component: <SignIn />,
  // },
  // {
  //   type: "collapse",
  //   name: "Sign Up",
  //   key: "sign-up",
  //   icon: <Icon fontSize="small">assignment</Icon>,
  //   route: "/authentication/sign-up",
  //   component: <SignUp />,
  // },
];

export default routes;
