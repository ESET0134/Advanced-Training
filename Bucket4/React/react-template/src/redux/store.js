import { configureStore } from "@reduxjs/toolkit";
import counterSlice from "./slices/CounterSlice";
import storage from 'redux-persist/lib/storage';
import { persistReducer } from "redux-persist";
import persistStore from "redux-persist/es/persistStore";
import { PERSIST } from "redux-persist";

const persistConfig = {
    key: 'redux-persist',
    storage
}

const persistedCounterSlice = persistReducer(persistConfig, counterSlice)

export const store = configureStore({
    reducer: {
        counter: persistedCounterSlice
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: {
                ignoredActions: [PERSIST],
            },
        }),
});

export const persistedStore = persistStore(store)