<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/custom/custom/Sys_Role_YDT.js此处编写
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
    import extend from "@/extension/custom/custom/Sys_Role_YDT.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Role_Id',
                footer: "Foots",
                cnName: 'YDT代码生成',
                name: 'custom/Sys_Role_YDT',
                url: "/Sys_Role_YDT/",
                sortName: "Role_Id"
            });
            const editFormFields = ref({"CreateDate":"","Creator":"","DeleteBy":"","DeptName":""});
            const editFormOptions = ref([[{"title":"创建时间","field":"CreateDate","type":"datetime"}],
                              [{"title":"创建人","field":"Creator","type":"text"}],
                              [{"title":"删除人","field":"DeleteBy","type":"text"}],
                              [{"dataKey":"组织机构","data":[],"title":"部门名称","field":"DeptName","type":"select"}]]);
            const searchFormFields = ref({});
            const searchFormOptions = ref([]);
            const columns = ref([{field:'Role_Id',title:'角色ID，自增长，主键',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'Creator',title:'创建人',type:'string',sort:true,width:130,align:'left'},
                       {field:'DeleteBy',title:'删除人',type:'string',sort:true,width:110,align:'left'},
                       {field:'DeptName',title:'部门名称',type:'string',bind:{ key:'组织机构',data:[]},width:110,align:'left'},
                       {field:'Dept_Id',title:'部门ID',type:'int',width:110,hidden:true,align:'left'},
                       {field:'Enable',title:'启用状态',type:'byte',width:110,hidden:true,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,hidden:true,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,hidden:true,align:'left',sort:true},
                       {field:'OrderNo',title:'排序号',type:'int',width:110,hidden:true,align:'left'},
                       {field:'ParentId',title:'父级ID',type:'int',width:110,hidden:true,require:true,align:'left'},
                       {field:'RoleName',title:'角色名称',type:'string',width:110,hidden:true,align:'left'}]);
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
