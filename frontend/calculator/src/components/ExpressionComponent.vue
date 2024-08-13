<template>
    <button class="btn" @click="calculate">=</button>
  </template>
  
  <script>
 const api = "http://localhost:5241/"
  
  export default {
    props: {
      expression: String
    },
    methods: {
      async calculate() {
        try {
            const encodedExpression = encodeURIComponent(this.expression);
            const response = 
            await fetch(api + `Calculation/ExpressionCalculate?expression=${encodedExpression}`)
            
            const result = await response.json(); 
            console.log(response);
            if (response.ok && result.statusCode==undefined){ 
                console.log(result.message);
                this.$emit('result', Number(result)); // преобразуем строку в число
            }
            else{

                this.$emit('result', result.message);
            }
        } catch (error) {
          console.error(error);
          this.$emit('result', 'Ошибка!');
        }
      },
    },
  };
  </script>

<style scoped>


.btn{
  background-color: #f2f2f2;
  border: 1px solid #999;
  font-size: 100%;
}

</style>