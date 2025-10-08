import { useTranslation } from 'react-i18next';
import { initDb } from './repo/indexedDb';
import Form from './components/Form';

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
    return <Form/>
}

export default App;
