<script lang="ts">


import ExpressionComponent from './ExpressionComponent.vue';

export default {
  components: {
    ExpressionComponent
  },
  data() {
    return{
      current:null as string | null,
      operator: '',
      expression: { expression: '', result: ''},
    }
  },

  methods:{
    clear(){
      this.current='';
    },

    sign(){
      console.log(this.current);
      if (this.current != "" || this.current != undefined)
      {
        this.current = String(this.current);
        console.log(this.current, typeof(this.current));
        this.current = this.current.charAt(0) === '-' ? this.current.slice(1) : `-${this.current}`
      }
    },

    append(number: string){
      this.current = `${this.current}${number}`
    },

    deleteLast(){
      this.current = String(this.current);
      this.current = this.current.slice(0,-1);
    },

    updateResult(operation: string, result: string) {
      this.current = result;
      console.log(result, operation);
    },

    async calculate() {
        const api = "http://localhost:5241/"
        try {
            const encodedExpression = encodeURIComponent(this.current);
            const response = 
            await fetch(api + `Calculation/ExpressionCalculate?expression=${encodedExpression}`)
            
            const result = await response.json(); 
            console.log(response);
            if (response.ok && result.statusCode==undefined){ 
                console.log(result.message);
                this.current = result.data;
                console.log(this.current);
            }
            else{
                this.$emit('result', result.message);
            }
        } catch (error) {
          console.error(error);
          this.$emit('result', 'Ошибка!');
        }
      },

  }
}
</script>


<template>
  <div class="calculator">
    <div class="display">
      {{ current || 0 }}
    </div>
    <div @click="clear" class="btn operatorRed">C</div>
    <div @click="sign()" class="btn operator">+/-</div>
    <div @click="append(`(`)" class="btn operator">(</div>
    <div @click="append(`)`)" class="btn operator">)</div>
    <div @click="append('/')" class="btn operator">/</div>
    <div @click="append('7')" class="btn">7</div>
    <div @click="append('8')" class="btn">8</div>
    <div @click="append('9')" class="btn">9</div>
    <div @click="append('*')" class="btn operator">*</div>
    <div @click="append('4')" class="btn">4</div>
    <div @click="append('5')" class="btn">5</div>
    <div @click="append('6')" class="btn">6</div>
    <div @click="append('-')" class="btn operator">-</div>
    <div @click="append('1')" class="btn">1</div>
    <div @click="append('2')" class="btn">2</div>
    <div @click="append('3')" class="btn">3</div>
    <div @click="append('+')" class="btn operator">+</div>
    <div @click="append('0')" class="btn">0</div>
    <ExpressionComponent :expression="current" @result="updateResult('expression', $event)" />
    <div @click="deleteLast()" class="btn operator">D</div>

  </div>
</template>

<style scoped>
.calculator{
  cursor: pointer;
  margin: 0 auto;
  width: 400px;
  font-size: 40px;
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  grid-auto-rows: minmax(50px, auto);
}

.display{
  grid-column: 1 /5;
  background-color: #333;
  color: white;
  text-align: center;
}

.btn{
  background-color: #f2f2f2;
  border: 1px solid #999;
  text-align: center;
}

.operator{
  background-color: orange;
  color:white;
}

.operatorRed{
  background-color: red;
  color:white;
}
</style>
