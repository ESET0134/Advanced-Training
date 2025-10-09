import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { increment, decrement } from '../../redux/slices/CounterSlice';

export default function HomePage() {
    const value = useSelector((state) => state.counter.value);
    const dispatch = useDispatch();
    const incrementHandler = () => {
        dispatch(increment());
    };
    const decrementHandler = () => {
        dispatch(decrement());
    };
    return (
        <div>
            This is home page: {value}
            <div>
                <button onClick={incrementHandler}>inc</button>
                <button onClick={decrementHandler}>dec</button>
            </div>
        </div>
    );
}
