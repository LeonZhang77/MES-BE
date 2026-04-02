<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/report/report/View_SalaryReportCover.js此处编写
 -->
<template>
    <view-grid ref="grid"
               :columns="columns"
               :detail="detail"
               :editFormFields="editFormFields"
               :editFormOptions="editFormOptions"
               :searchFormFields="searchFormFields"
               :searchFormOptions="searchFormOptions"
               :table="table"
               :extend="extend">
    </view-grid>
</template>
<script>
    import extend from "@/extension/report/report/View_SalaryReportCover.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'ID',
                footer: "Foots",
                cnName: '人员绩效考核',
                name: 'report/View_SalaryReportCover',
                url: "/View_SalaryReportCover/",
                sortName: "ReportDate"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"ReportDate":"","ProductUser":""});
            const searchFormOptions = ref([[{"title":"报工时间","field":"ReportDate","type":"date"},{"dataKey":"users","data":[],"title":"生产人员","field":"ProductUser","type":"select"}]]);
            const columns = ref([
                       {field:'ReportDate',title:'报工时间',type:'string',width:110,align:'left'},
                       {field:'ProductUser',title:'生产人员',type:'string',bind:{ key:'users',data:[]},width:180,require:true,align:'left'},
                       {field:'UserName',title:'账号',type:'string',width:120,align:'left'},
                       {field:'UserTrueName',title:'姓名',type:'string',sort:true,width:110,align:'left'},
                       {field:'OverPercent',title:'完成率',type:'string',sort:true,width:120,align:'left'},
                       {field:'NoOverPercent',title:'损耗率',type:'string',sort:true,width:120,align:'left'},
                       {field:'Award',title:'应奖',type:'decimal',sort:true,width:110,align:'left'},
                       {field:'Penalty',title:'应罚',type:'decimal',sort:true,width:110,align:'left'},
                       {field:'UnitPrice',title:'单价',type:'decimal',sort:true,width:110,align:'left'}]);
            const detail = ref({
                cnName: "#detailCnName",
                table: "#detailTable",
                columns: [],
                sortName: "",
                key: ""
            });
            return {
                table,
                extend,
                editFormFields,
                editFormOptions,
                searchFormFields,
                searchFormOptions,
                columns,
                detail,
            };
        },
    });
</script>
