import React from 'react'
import NavbarProtected from '../components/navbar-protected/NavbarProtected'
import Footer from '../components/footer/Footer'
import { Outlet } from 'react-router-dom'
import SideBar from '../components/sidebar/SideBar'

export default function ProtectedLayout() {
  return (
    <div>
        <NavbarProtected/>
        <div style={{display:'flex',flexDirection:'row'}}>
            <div><SideBar/></div>
            <div><Outlet/></div>
        </div>
        <Footer/>

    </div>
  )
}
