<template>
    <div>
        <MesBox
        v-model="model"
        :lazy="true"
        title="BOM批量出库"
        :height="700"
        :width="700"
        :padding="15"
      >
        <div style="padding-bottom: 10px">
            <span style="margin-right: 10px">数量：</span>
            <el-input-number v-model="qty" @change="handleChange" :min="1" :max="10" label="请输入数量"></el-input-number>
            <span style="margin-right: 10px;margin-left: 10px">备注：</span>
            <el-input
              placeholder="请输入备注"
              style="width: 300px"
              v-model="remark"
            />
          </div>
            <div style="padding-bottom: 2px;">
                <el-button
                type="primary"
                size="medium"
                @click="getParentEl()"
                > <i class="el-icon-zoom-out"></i>出库</el-button
              >
              <el-button
              type="warning"
              size="medium"
              @click="()=>{model=false}"
              > <i class="el-icon-close"></i>关闭</el-button
            >
    
      </div>
      </MesBox>
    </div>
  </template>
  <script>
  import MesBox from "@/components/basic/MesBox.vue";
  export default {
    components: { MesBox },
    data() {
      return {
        text: "无",
        model: false,
        qty: "", //数量
        remark:"",  //备注
      };
    },
    methods: {
      handleChange(value) {
        console.log(value);
      },
      getParentEl() {
        this.$emit("parentCall", $vue => {
          //获取明细表$vue.getDetailSelectRows()选中的行;
          let rows = $vue.getSelectRows();
          if (rows.length == 0) {
            return this.$Message.error("请先请选中查询界面的行数据");
          }
          if(this.qty == ""){
            return this.$Message.error("请先输入数量！");
          }
          this.text = JSON.stringify(rows);
          let url = `api/Base_MaterialDetailTree/bomOut?materialDetailTreeId=${rows[0].MaterialDetailTree_Id}&qty=${this.qty}&remark=${this.remark}`;
            this.http.post(url, {}).then((result) => {
                this.model = false;
                this.$Message.success("BOM批量出库成功！");
            });
        });
      }
    }
  };
  </script>
   