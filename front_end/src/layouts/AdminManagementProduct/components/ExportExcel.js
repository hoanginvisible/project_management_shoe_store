import * as xlsx from 'xlsx';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faFileCsv} from "@fortawesome/free-solid-svg-icons";
import {Button} from "antd";
import React from "react";

const ExportExcel = ({ data }) => {

    const exportToExcel = () => {
        const worksheet = xlsx.utils.json_to_sheet(data);
        const workbook = xlsx.utils.book_new();
        xlsx.utils.book_append_sheet(workbook, worksheet, 'Data');

        // Xuất file
        xlsx.writeFile(workbook, 'Danh sách sản phẩm.xlsx');
    }

    return (
        <Button type="primary" className="btn-form-event" onClick={exportToExcel} style={{backgroundColor: "#217346", marginRight: "7px"}}>
            <FontAwesomeIcon
                icon={faFileCsv}
                style={{ color: "#ffffff", marginRight: "7px" }}
            />
            Export Excel
        </Button>
    );
}

export default ExportExcel;