import { createSlice } from "@reduxjs/toolkit";
const counterSlice = createSlice({
    name:"counter",
    initialState: {value:0},
    reducers:{
        increment : (state) =>{
            state.value = state.value+1;
        },
        decrement:(state)=>{
            state.value = state.value-1;
        },
        setValue: (state, payload) =>{
            state.value = payload.payload.value
        }
    }
})
export const {increment,decrement,setValue} = counterSlice.actions
export default counterSlice.reducer;