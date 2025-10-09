import React from 'react'
import { BrowserRouter, Router, Route, Routes } from 'react-router-dom'
import PublicLayout from './PublicLayout'
import LoginPage from '../pages/user/public/login/LoginPage'
import ProtectedLayout from './ProtectedLayout'
import NotFoundPage from '../pages/utility/NotFoundPage'
import HomePage from '../pages/user/HomePage'
export default function RouterSetup() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='' element={<ProtectedLayout/>}>
            <Route path='' element={<HomePage/>}/>
        </Route>
        <Route path='*' element={<NotFoundPage/>}/>
      </Routes>
    </BrowserRouter>
  )
}
