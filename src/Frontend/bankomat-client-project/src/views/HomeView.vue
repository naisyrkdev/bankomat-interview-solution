<script>
import axios from 'axios'

export default {
  data()
  {
    return {
      user: {
        firstName:'janusz',
        lastName:'',
        balance: 0
      },
      withdrawMoney: {
        bankomatId: 0,
        bankAccountId: 0,
        amountOfMoney: 0
      }
    }
  },
  mounted(){
    console.log("here")
    axios.get('https://localhost:7274/users/' + 1)
    .then(function (response) {
                    console.log("printing data from put CANDIDATE", response.data);
                }).finally();
  },
  methods: {
    async submitForm() {
      const submitWithdrawMoney = {
        bankomatId: 1,
        bankAccountId: 1,
        amountOfMoney: this.amountOfMoney
      }
      axios.post('https://localhost:7274/bank-account/withdraw-money', submitWithdrawMoney)
        .then(function (response)
        {
          console.log("printing data from put withdarwingmoney", response.data);
        }).finally();
    }
    }
}
</script>




<template>
  <div class="container">
    <div class="row">
      <div class="justify-content-center align-content-center sample-window">
        <a>{{ this.user.firstName }}</a>
    <a>{{ this.user.lastName }}</a>
    <a>{{ this.user.balance }}</a>
    <div>
      <form @submit.prevent="submitForm">
        <div class="mb-3">
          <label class="form-label">First Name</label>
          <input v-model="withdrawMoney.amountOfMoney" type="text" class="form-control" aria-describedby="">
        </div>
        <div class="d-flex justify-content-center">
          <button type="submit" class="button-main">withdraw</button>
        </div>
        </form>
        {{withdrawMoney.amountOfMoney}}
    </div>
      </div>

    </div>
    
  </div>
</template>
<style>
.sample-window {
  width: 500px;
  height: 500px;
}


</style>