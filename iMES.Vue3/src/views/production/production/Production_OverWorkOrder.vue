<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/production/production/Production_OverWorkOrder.js此处编写
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
    import extend from "@/extension/production/production/Production_OverWorkOrder.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'OverWorkOrder_Id',
                footer: "Foots",
                cnName: '完工单',
                name: 'production/Production_OverWorkOrder',
                url: "/Production_OverWorkOrder/",
                sortName: "OverWorkOrder_Id"
            });
            const editFormFields = ref({});
            const editFormOptions = ref([]);
            const searchFormFields = ref({"WorkOrderCode":"","ProcessName":"","ProcessCode":""});
            const searchFormOptions = ref([[{"title":"工单编号","field":"WorkOrderCode","type":"like"},{"title":"工序名称","field":"ProcessName","type":"like"},{"title":"工序编号","field":"ProcessCode","type":"like"}]]);
            const columns = ref([{field:'OverWorkOrder_Id',title:'完工单主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'WorkOrder_Id',title:'工单',type:'int',bind:{ key:'workOrderList',data:[]},sort:true,width:110,require:true,align:'left',sort:true},
                       {field:'WorkOrderCode',title:'工单编号',type:'string',sort:true,width:180,align:'left'},
                       {field:'Process_Id',title:'工序',type:'int',sort:true,width:110,hidden:true,require:true,align:'left'},
                       {field:'ProcessName',title:'工序名称',type:'string',sort:true,width:180,require:true,align:'left'},
                       {field:'ProcessCode',title:'工序编号',type:'string',width:180,require:true,align:'left'},
                       {field:'Status',title:'审批状态',type:'int',bind:{ key:'audit',data:[]},width:110,require:true,align:'left'},
                       {field:'ApproverUserName',title:'审批人',type:'string',width:180,require:true,align:'left'},
                       {field:'ApproverDate',title:'审批时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateDate',title:'创建时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',sort:true,width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
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
