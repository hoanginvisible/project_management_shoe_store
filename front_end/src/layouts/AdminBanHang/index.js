import Grid from "@mui/material/Grid";
import MDBox from "components/MDBox";
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Footer from "examples/Footer";
import BanHang from "./components/BanHang";

function IndexBanHang() {
    return (
        <DashboardLayout>
            <DashboardNavbar/>
            <MDBox py={3}>
                <Grid container spacing={3}>
                    <Grid item xs={12} md={0} lg={0}>
                        <MDBox mb={1.5}>
                            <BanHang/>
                        </MDBox>
                    </Grid>
                </Grid>
            </MDBox>
            <Footer/>
        </DashboardLayout>
    );
}

export default IndexBanHang;
