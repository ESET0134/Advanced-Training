import { useTranslation } from 'react-i18next';
import { initDb } from './repo/indexedDb';
import Form from './components/Form';
import { Provider } from 'react-redux';
import RouterSetup from './router/RouterSetup';
import { store, persistedStore } from './redux/store';
import { PersistGate } from 'redux-persist/integration/react';
import './index.css'

function App() {
    // const {t,i18n} = useTranslation();

    // const insertSomeData =async () =>{
    //   const db = await initDb();
    //   db.add('user',{'username':'shruti', 'phone': 987654321})
    // }
    // return <div>
    //   {t('welcome')}
    //   <div>
    //     <button onClick={()=>{i18n.changeLanguage('en')}}>en</button>
    //     <button onClick={()=>{i18n.changeLanguage('fr')}}>fr</button>
    //   </div>
    //   <div>
    //     <button onClick={()=>{insertSomeData()}}>Add User</button>
    //   </div>
    // </div>;
    // return <Form/>
    return (
        // <>
        //     <Provider store={store}>
        //         <PersistGate persistor={persistedStore}>
        //             <RouterSetup />
        //         </PersistGate>
        //     </Provider>
        // </>
        <div class='bg-red-300'>
            Hello World!
        </div>
    );
}

export default App;
